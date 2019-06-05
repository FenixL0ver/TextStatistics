using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Доп_задания
{
    class Dictionary
    {
        private string _name;
        private DateTime _date;
        private Dictionary<string, Offense> _directory;
        public string Name
        {
            get { return this._name; }
            set { Debug.Assert(value != "");
                _name = value;
                _date = System.DateTime.Now;
            }
        }
        public DateTime Date
        {
            get { return this._date; }
        }

        public Dictionary(string name)
        {
            Debug.Assert(Name != "");
            this.Name = name;
            this._date = System.DateTime.Now;
            this._directory = new Dictionary<string, Offense>();
        }
        public void PrintDictionaryName()
        {
            Console.WriteLine($"Название справочника: {this.Name} Дата последнего изменения: {this.Date}");
        }
        public void PrintDictionary()
        {
            foreach (var x in this._directory)
            {
                Console.WriteLine($"Номер статьи:{x.Key}");
                x.Value.PrintTheOffense();
            }
        }
        public void DateBaseAdd(Offense offence,string id)
        {
            Debug.Assert(id.Where(x => Char.IsDigit(x)).Count() != 0);
            _directory.Add(id, offence);
            _date = System.DateTime.Now;
        }
        public void RemoveOffense(string offense)
        {
            if (this._directory.ContainsKey(offense))
            {
                this._directory.Remove(offense);
                this._date = System.DateTime.Now;
            }
        }
        public int IdGetFine(string article)
        {
            if (this._directory.ContainsKey(article))
            {
                return this._directory[article].Value;
            }
            Console.WriteLine("Неверный индекс");
            return -1;
        }
        
        public void DirectoryToFile (string file_name)
        {
            using (var fs = new FileStream(file_name, FileMode.Create))
            using (var sw = new StreamWriter(fs))
            {
                foreach (var x in _directory)
                {
                    sw.WriteLine(x.Value);
                }
            }
        }

        public void FillTheDirectory(string file_name)
        {
            using (var fs = new FileStream(file_name + ".txt", FileMode.Open))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            {
                while (!sr.EndOfStream)
                {
                    var s = sr.ReadLine();
                    char[] delims = new char[] { '&' };
                    var ss = s.Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    var ID = ss[0];
                    var Name = ss[1];
                    var Description = ss[2];
                    var Value = ss[3];
                    Offense offense = new Offense(Name, Description, int.Parse(Value));
                    this.DateBaseAdd(offense, ss[0]);
                }
            }
        }


    }
}
