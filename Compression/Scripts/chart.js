google.load("visualization", "1", { packages: ["corechart"] });
google.setOnLoadCallback(drawCharts);
function drawCharts() {

	// BEGIN BAR CHART
	/*
	// create zero data so the bars will 'grow'
	var barZeroData = google.visualization.arrayToDataTable([
	  ['Day', 'Page Views', 'Unique Views'],
	  ['Sun',  0,      0],
	  ['Mon',  0,      0],
	  ['Tue',  0,      0],
	  ['Wed',  0,      0],
	  ['Thu',  0,      0],
	  ['Fri',  0,      0],
	  ['Sat',  0,      0]
	]);
	  */
	// actual bar chart data
	var barData = google.visualization.arrayToDataTable([
		['Kompresja', 'Przed', 'Po'],
		['Kompresja', 20, 30]
	]);
	// set bar chart options
	var barOptions = {
		focusTarget: 'category',
		backgroundColor: 'transparent',
		colors: ['cornflowerblue', 'tomato'],
		fontName: 'Open Sans',
		chartArea: {
			left: 50,
			top: 10,
			width: '50%',
			height: '70%'
		},
		bar: {
			groupWidth: '40%'
		},
		hAxis: {
			textStyle: {
				fontSize: 11
			}
		},
		vAxis: {
			minValue: 0,
			maxValue: 150,
			baselineColor: '#DDD',
			gridlines: {
				color: '#DDD',
				count: 4
			},
			textStyle: {
				fontSize: 11
			}
		},
		legend: {
			position: 'bottom',
			textStyle: {
				fontSize: 12
			}
		},
		animation: {
			duration: 1200,
			easing: 'out',
			startup: true
		}
	};
	// draw bar chart twice so it animates
	var barChart = new google.visualization.ColumnChart(document.getElementById('bar-chart'));
	//barChart.draw(barZeroData, barOptions);
	barChart.draw(barData, barOptions);
}