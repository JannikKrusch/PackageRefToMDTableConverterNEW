// See https://aka.ms/new-console-template for more information
using NewPackageRefToMDTableConverter;

Console.WriteLine("Hello, World!");

var logger = new Logger();
var inputService = new InputService(logger);
var converter = new Converter(logger);

inputService.SetPath();
inputService.SetSeparate();

converter.StartConverting(inputService.Path, inputService.Separate);

//todo
//  * create constant folder and create table header constants
//  * refactor code
