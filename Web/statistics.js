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
        var winRatio = sample[2];
        if(winRatio > statistics.maximumWinRatio)
            statistics.maximumWinRatio = winRatio;
    });
    this.statistics.push([title, samples]);
}

function generatePercentageBarCell(ratio, maximumRatio)
{
    var percentage = ratio * 100;
    var bar = span(percentage.toFixed(1) + '%');
    bar.className = 'percentage';
    var barRatio = ratio / maximumRatio;
    var barRatioMinimum = 0.18;
    var barRatioMaximum = 0.97;
    if(barRatio < barRatioMinimum)
        barRatio = barRatioMinimum;
    if(barRatio > barRatioMaximum)
        barRatio = barRatioMaximum;
    var barPercentage = barRatio * 100;
    bar.style.width = barPercentage + '%';
    var cell = tableCell(bar);
    cell.className = 'percentage';
    return cell;
}

function generateTable(title, samples)
{
    var statistics = this;
    var rows = [
        tableHead('Description'),
        tableHead('Win ratio'),
        tableHead('Popularity'),
    ];
    var sampleSum = 0;
    var maximumSamples = 0;
    samples.forEach(function(sample) {
        var sampleCount = sample[1];
        if(sampleCount >= maximumSamples)
            maximumSamples = sampleCount;
    });
    var maximumFrequencyRatio = maximumSamples / this.validSamples;
    samples.forEach(function(sample) {
        var description = sample[0];
        var sampleCount = sample[1];
        var winRatio = sample[2];

        var descriptionCell = tableCell(description);
        descriptionCell.className = 'description';

        var winRatioBarCell = generatePercentageBarCell(winRatio, statistics.maximumWinRatio)
        var frequencyRatio = sampleCount / statistics.validSamples;
        var frequencyBarCell = generatePercentageBarCell(frequencyRatio, maximumFrequencyRatio)

        var row = tableRow(
            descriptionCell,
            winRatioBarCell,
            frequencyBarCell
        );
        rows.push(row);
    });
    var header = header2(title);
    var output = table(rows);
    document.body.appendChild(header);
    document.body.appendChild(output);
}

function generateStatistics()
{
    var statistics = this;
    this.statistics.forEach(function(i) {
        var title = i[0];
        var samples = i[1];
        statistics.generateTable(title, samples);
    });
    document.getElementById('sampleCount').appendChild(text(this.validSamples));
}