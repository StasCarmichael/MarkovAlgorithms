using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkovAlgorithmsWindowsForms
{
    class MarkovAlgorithm
    {
        private MarkovCommand[] markovCommands;
        private string myWord;
        public List<string> logs { get; protected set; }
        public bool donwload { get; protected set; }


        #region MarkovCommand
        protected class MarkovCommand
        {
            public string key;
            public string value;
            public bool stopState;

            //ctor
            public MarkovCommand()
            {
                key = string.Empty;
                value = string.Empty;
                stopState = false;
            }


            public void CreateCommand(string str)
            {
                string[] stringArray = str.Split(' ', '-', '>', '\t', 'n');

                int tempIndex = 0;
                for (int i = 0; i < stringArray.Length; i++)
                {
                    if (stringArray[i].Length != 0)
                    {
                        if (tempIndex == 0)
                        {
                            key = stringArray[i];
                        }
                        else if (tempIndex == 1)
                        {
                            if (stringArray[i][0] == '.')
                            {
                                stopState = true;
                                for (int index = 1; index < stringArray[i].Length; index++)
                                {
                                    value += stringArray[i][index];
                                }
                            }
                            else
                            {
                                stopState = false;
                                value = stringArray[i];
                            }
                        }

                        tempIndex++;
                    }
                }
            }
        }
        #endregion

        //ctor
        public MarkovAlgorithm()
        {
            markovCommands = new MarkovCommand[0];
            myWord = string.Empty;
            logs = new List<string>();
            donwload = false;
        }


        public void DownloadData(string[] stringArray)
        {
            markovCommands = new MarkovCommand[stringArray.Length];
            for (int i = 0; i < markovCommands.Length; i++)
            {
                markovCommands[i] = new MarkovCommand();
            }


            for (int i = 0; i < stringArray.Length; i++)
            {
                markovCommands[i].CreateCommand(stringArray[i]);
            }

            donwload = true;
        }

        public void AddInputWords(string word) { myWord = word; }

        public string StartMarkovMachine()
        {
            logs.Clear();

            string result = myWord;
            bool statusMachine = true;

        //goto
        TryAgain:
            while (statusMachine)
            {
                for (int i = 0; i < markovCommands.Length; i++)
                {
                    if (markovCommands[i].key == "e")
                    {
                        result = markovCommands[i].value + result;
                        if (markovCommands[i].stopState == true) { statusMachine = false; }
                        else { statusMachine = true; }

                        //Логирования
                        logs.Add(logs.Count + 1 + "# " + result);

                        goto TryAgain;
                    }

                    if (result.Contains(markovCommands[i].key))
                    {

                        int firstIndex = result.IndexOf(markovCommands[i].key);
                        result = result.Remove(firstIndex, markovCommands[i].key.Length);


                        if (markovCommands[i].value != "e")
                        {
                            result = result.Insert(firstIndex, markovCommands[i].value);
                        }
                        else { }

                        //Логирования
                        logs.Add(logs.Count + 1 + "# " + result);

                        if (markovCommands[i].stopState == true) { statusMachine = false; }
                        else { statusMachine = true; }

                        goto TryAgain;
                    }
                }
                statusMachine = false;
            }
            return result;
        }

    }
}
