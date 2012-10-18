Array.prototype.isArray = function()
{
    return true;
}

function parseArguments(argumentObject)
{
    return Array.prototype.slice.call(argumentObject);
}

function createElement(tag, children)
{
    var element = document.createElement(tag);
    //Extensions
    element.add = addChild;
    element.purge = removeChildren;
    if(children !== undefined)
    {
        children.forEach(function(child) {
            element.add(child);
        });
    }
    return element;
}

function addChild(input)
{
    if(input === undefined)
    {
        trace();
        throw 'Tried to add an undefined component';
    }
    if(typeof input == 'string')
        input = text(input);
    else if(typeof input == 'number')
        input = text(input.toString());
    else if(input.isArray)
    {
        var container = this;
        input.forEach(function(i) {
            container.add(i);
        });
        return;
    }
    else if(arguments.length > 1)
    {
        var container = this;
        parseArguments(arguments).forEach(function(i) {
            container.add(i);
        });
        return;
    }
    try
    {
        this.appendChild(input);
    }
    catch(exception)
    {
        //Firebug only
        if(console !== undefined)
            console.trace();
        throw exception;
    }
}

function removeChildren()
{
    while(this.hasChildNodes())
        this.removeChild(this.lastChild);
}

function text(text)
{
    var element = document.createTextNode(text);
    return element;
}

function table()
{
    return createElement('table', parseArguments(arguments));
}

function tableRow()
{
    return createElement('tr', parseArguments(arguments));
}

function tableCell()
{
    return createElement('td', parseArguments(arguments));
}

function tableHead()
{
    return createElement('th', parseArguments(arguments));
}

function list()
{
    return createElement('ul', parseArguments(arguments));
}

function orderedList()
{
    return createElement('ol', parseArguments(arguments));
}

function listElement()
{
    return createElement('li', parseArguments(arguments));
}

function diverse()
{
    return createElement('div', parseArguments(arguments));
}

function paragraph()
{
    return createElement('p', parseArguments(arguments));
}

function span()
{
    return createElement('span', parseArguments(arguments));
}

function header1()
{
    return createElement('h1', parseArguments(arguments));
}

function header2()
{
    return createElement('h2', parseArguments(arguments));
}

function header3()
{
    return createElement('h3', parseArguments(arguments));
}