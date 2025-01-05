namespace Utility
{
    public static class DatabaseURL
    {
        private const string SpreadSheetURL =
            "https://docs.google.com/spreadsheets/d/1UtK50bbNTtRE6MBpp3APbRVSVEBJiaxItFYo3z8-4YM/gviz/tq?tqx=out:csv&sheet=";

        public static string GetDataURL(SheetName sheetName) => SpreadSheetURL + sheetName;
        
        public enum SheetName
        {
            Spell,
            Attack
        }
    }
}