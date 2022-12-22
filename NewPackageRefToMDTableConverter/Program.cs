// See https://aka.ms/new-console-template for more information
using NewPackageRefToMDTableConverter;

Console.WriteLine("Hello, World!");

var logger = new Logger();
var inputService = new InputService(logger);

inputService.SetUserInput();
logger.Log = inputService.Log;

var converter = new Converter(logger);

converter.StartConverting(inputService.Path, inputService.Separate);

//todo
//  * ask if user wants logs x
//  * create constant folder and create table header constants x
//  * refactor code
