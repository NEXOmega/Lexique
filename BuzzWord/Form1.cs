﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BuzzWord
{
    public partial class Form1 : Form
    {
        private CLexique _lexique;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnReadLexique_Click(object sender, EventArgs e)
        {
            const string path = @"F:\github\lexique\wordlist\";
            _lexique = new CLexique();
            _lexique.ReadLexique3(path + @"Lexique3.txt");
            _lexique.ReadWordList(path + @"liste.de.mots.francais.frgut.txt");
            _lexique.ReadWordList(path + @"liste_francais.txt");
            _lexique.ReadWordList(path + @"ods4.txt");
            _lexique.ReadWordList(path + @"ODS5.txt");
            _lexique.ReadWordList(path + @"pli07.txt");
            _lexique.ReadCSV(path + @"DicFra.csv");
            _lexique.ReadTxt(path + @"dict.xmatiere.com.16.csvtxt");
            _lexique.ReadWordList(path + @"liste16.txt");
            _lexique.Distinct();
            lblWordCount.Text = String.Format("{0}", _lexique.WordCount);
        }


        private void btnReadLexiqueEN_Click(object sender, EventArgs e)
        {
            const string path = @"D:\github\lexique\wordlist\";
            _lexique = new CLexique();
            _lexique.ReadWordList(path + "sowpods.txt");
            lblWordCount.Text = String.Format("{0}", _lexique.WordCount);
        }

        private void btnGetBuzzWordList_Click(object sender, EventArgs e)
        {
            //lbResults.Items.Clear();
            if (_lexique != null)
            {
                List<CBuzzWord> results = _lexique.GetBuzzWordList(txtBuzzWord.Text.ToLower(), Int32.Parse(txtWordMinLength.Text));
                if (results == null)
                {
                    results = new List<CBuzzWord>
                    {
                        new CBuzzWord("No results")
                    };
                    lbResults.DataSource = results;
                    lblBuzzWordCount.Text = @"0";
                    lblBuzzWordTop5.Text = @"0";
                }
                else
                {
                    lblBuzzWordCount.Text = String.Format("{0}", results.Count);
                    lbResults.DataSource = results;
                    int top5 = 0;
                    for (int i = 0; i < (results.Count > 5 ? 5 : results.Count); i++)
                        top5 += results[i].Value;
                    lblBuzzWordTop5.Text = String.Format("{0}", top5);
                }
            }
            else
            {
                lbResults.Items.Add("No lexique loaded");
                lblBuzzWordCount.Text = "";
                lblBuzzWordTop5.Text = "";
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //lbResults.Items.Clear();
            if (_lexique != null)
            {
                List<CSortedBuzzWord> results = _lexique.GetBestBuzzWords(13, 16);
                if (results == null)
                {
                    results = new List<CSortedBuzzWord>
                    {
                        new CSortedBuzzWord("No results")
                    };
                    lbResults.DataSource = results;
                    lblBuzzWordCount.Text = @"0";
                    lblBuzzWordTop5.Text = @"0";
                }
                else
                {
                    lblBuzzWordCount.Text = String.Format("{0}",results.Count);
                    lbResults.DataSource = results;

                    int top5 = 0;
                    for (int i = 0; i < (results.Count > 5 ? 5 : results.Count); i++)
                        top5 += results[i].Value;
                    lblBuzzWordTop5.Text = String.Format("{0}", top5);
                }
            }
            else
            {
                lbResults.Items.Add("No lexique loaded");
                lblBuzzWordCount.Text = "";
                lblBuzzWordTop5.Text = "";
            }
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            //lbResults.Items.Clear();
            if (_lexique != null)
            {
                IOrderedEnumerable<KeyValuePair<int, int>> results = _lexique.GetWordCountByLetters();
                if (results == null)
                {
                    lbResults.Items.Add("No results");
                }
                else
                {
                    lbResults.DataSource = results.ToList();
                    //foreach (KeyValuePair<int, int> kv in results)
                    //    lbResults.Items.Add(kv.Key.ToString() + " => " + kv.Value.ToString());
                    //lbResults.DataSource = results;
                }
            }
            else
            {
                lbResults.Items.Add("No lexique loaded");
            }
        }

        private void btnCrossword_Click(object sender, EventArgs e)
        {
            if (_lexique != null)
            {
                List<string> results = _lexique.CrossWords(txtBuzzWord.Text.ToLower());
                if (results == null)
                {
                    lbResults.Items.Add("No results");
                }
                else
                {
                    lbResults.DataSource = results.ToList();
                    //foreach (KeyValuePair<int, int> kv in results)
                    //    lbResults.Items.Add(kv.Key.ToString() + " => " + kv.Value.ToString());
                    //lbResults.DataSource = results;
                }
            }
            else
            {
                lbResults.Items.Add("No lexique loaded");
            }
        }

        private void btnScrabble_Click(object sender, EventArgs e)
        {
            if (_lexique != null)
            {
                List<string> results = _lexique.GetScrabble(txtBuzzWord.Text.ToLower());
                if (results == null)
                {
                    lbResults.Items.Add("No results");
                }
                else
                {
                    lbResults.DataSource = results.ToList();
                    //foreach (KeyValuePair<int, int> kv in results)
                    //    lbResults.Items.Add(kv.Key.ToString() + " => " + kv.Value.ToString());
                    //lbResults.DataSource = results;
                }
            }
            else
            {
                lbResults.Items.Add("No lexique loaded");
            }
        }
    }
}
