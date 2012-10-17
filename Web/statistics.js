function Statistics(validSamples)
{
    this.validSamples = validSamples;
    this.maximumWinRatio = 0.0;
    this.statistics = [];

    this.addStatistics = addStatistics;
    this.generateTable = generateTable;
    this.generateStatistics = generateStatistics;
}

function addStatistics(title, samples)
{
    var statistics = this;
    samples.forEach(function(sample) {
        var winRatio = sample[1];
        if(winRatio > statistics.maximumWinRatio)
            statistics.maximumWinRatio = winRatio;
    });
    this.statistics.push([title, samples]);
}

function generateTable(title, samples)
{
    var statistics = this;
    var rows = [];
    samples.forEach(function(sample) {
        var description = sample[0];
        var winRatio = sample[1];
        var percentage = winRatio * 100;
        var bar = diverse(percentage.toFixed(1) + '%');
        bar.className = 'percentage';
        var barPercentage = winRatio / statistics.maximumWinRatio * 100;
        bar.style.width = barPercentage + '%';
        var descriptionCell = tableCell(description);
        descriptionCell.className = 'description';
        var row = tableRow(
            descriptionCell,
            tableCell(bar)
        );
        rows.push(row);
    });
    var output = table(rows);
    document.body.appendChild(output);
}

function generateStatistics()
{
    var statistics = this;
    this.statistics.forEach(function(i) {
        statistics.generateTable(i[0], i[1]);
    });
    document.getElementById('sampleCount').appendChild(text(this.validSamples));
}