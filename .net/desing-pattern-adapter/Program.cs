using desing_pattern_adapter;

Console.WriteLine("This is an implemetation of the Adapter Desing Pattern.\n\r");
Console.WriteLine("Reading CSV file...\n\r");
string LsCsvContent = File.ReadAllText("./CsvFile.csv");
Console.WriteLine("CSV Content: ");
Console.WriteLine(LsCsvContent+ "\n\r");
CsvToJsonAdapter LoAdapter = new CsvToJsonAdapter(LsCsvContent, ",", "\r\n");
Console.WriteLine("Converting to JSON...\n\r\n\rPrinting Json result: ");
Console.Write(LoAdapter.ToJson().ToString());
LoAdapter.Dispose();