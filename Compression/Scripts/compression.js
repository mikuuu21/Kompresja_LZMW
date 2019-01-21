/// <reference path="jquery-3.3.1.js" />
$(document).ready(function () {
    compression.Init();
});

var compression = {
    before: 0,
    after:0,

    Init: function () {

        $('.comp').click(function () {

            compression.compressInput();

        });
        $('.decomp').click(function () {

            compression.decompressInput();

        });

    },
    compressInput: function () {

        var $compressionTextArea = $('textarea.compress');
        var $decompressionTextArea = $('textarea.decompress');
        var textValue = $compressionTextArea.val();
        if (textValue !=="") {
            compressionApi.compressText(textValue).then(function (response) {
                $compressionTextArea.val('');
                $decompressionTextArea.val(response.compressedFile);
                compression.before = response.beforeCompression;
                compression.after = response.afterCompression;

                var compressedValuePercent = ((response.afterCompression / response.beforeCompression) * 100).toFixed(1);
                var compressionPercent = (100 - compressedValuePercent).toFixed(1);
                compressionPercent += "%";
                var percent = compressedValuePercent.toString();
                percent += "%";

                $('div.bar1').text(response.beforeCompression);
                $('div.bar2').text(response.afterCompression);
                $('div.bar3').text(compressionPercent);
                $('.bar2').append('<style>.bar2::after{ max-width:' + percent +' }</style>');
                $('.bar3').append('<style>.bar3::after{ max-width:' + compressionPercent + ' }</style>');
                $('.graph-cont').removeClass('hidden');


            })
                .fail(function myfunction() {

                });
        }

    },
    decompressInput: function () {
        var $compressionTextArea = $('textarea.compress');
        var $decompressionTextArea = $('textarea.decompress');
        var compressedValue = $decompressionTextArea.val();
        if (compressedValue !== "") {
            compressionApi.decompressText(compressedValue).then(function (response) {
                $decompressionTextArea.val('');
                $compressionTextArea.val(response.decodedString);


            })
                .fail(function myfunction() {

                });
        }

    },

};

var compressionApi = {

    compressText: function (text) {
        return $.ajax({
            type: "get",
            url: '../api/compression/compress',
            data: { 'text': text }
        });
    },
    decompressText: function (compressedValue) {
        return $.ajax({
            type: "get",
            url: '../api/compression/decompress',
            data: { 'text': compressedValue }
        });
    }
};