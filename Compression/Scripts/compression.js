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

        compressionApi.compressText(textValue).then(function (response) {
            $compressionTextArea.val('');
            $decompressionTextArea.val(response.compressedFile);
            compression.before = response.beforeCompression;

        })
        .fail(function myfunction() {

         });
    },
    decompressInput: function () {
        var $compressionTextArea = $('textarea.compress');
        var $decompressionTextArea = $('textarea.decompress');
       var compressedValue =  $decompressionTextArea.val();

        compressionApi.decompressText(compressedValue).then(function (response) {

            $compressionTextArea.val(response.decompressed);
            compression.after = response.afterCompression;


        })
            .fail(function myfunction() {

            });
    }
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