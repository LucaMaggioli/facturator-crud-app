using facturator_api.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace facturator_api.DataProviders
{
    public class ArticleDataProvider
    {

        //private string path = @"C:\Users\maggioli\Desktop\Apprentissage\EPSIC-3\i326\facturator\facturator-api-dotnetcore\facturator-api\Data\Articles.csv";
        
        private string path = @"C:\Users\mm\Desktop\WorkDirectory\Apprentissage\EPSIC-3\Exam-sem-1-facturator\facturator-crud-app\facturator-api-dotnetcore\facturator-api\Data\Articles.csv";

        public List<Article> getArticles()
        {
            List<Article> articles = new List<Article>();

            try
            {
                string[] lines = System.IO.File.ReadAllLines(this.path);
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
                    int id;
                    int.TryParse(columns[0], out id);
                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.CurrencyDecimalSeparator = ".";
                    decimal price = decimal.Parse(columns[3], CultureInfo.InvariantCulture.NumberFormat);
                    articles.Add(new Article(id, columns[1], columns[2], price, columns[4]));
                }
            }
            catch (FileNotFoundException exception)
            {
                Console.WriteLine(exception);
            }

            return articles;
        }

        public async void AddArticle(string name, string photoUrl, string price, string description)
        {
            try
            {
                //get Id for new client
                string[] lines = System.IO.File.ReadAllLines(this.path);
                int id = lines.Length;

                //add new Client to file
                using StreamWriter file = new StreamWriter(this.path, append: true);
                file.WriteLine(id + ", " + name + ", " + photoUrl + ", " + price + "," + description + ",");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
