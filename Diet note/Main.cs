﻿using System;
using System.Collections.Generic;

using System.Drawing;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Diet_note
{

    public partial class Main : Form
    {
        public Main()
        {


            InitializeComponent();

            using (var db = new Aplicatincontext())
            {

                NamelistBox.Items.AddRange(db.Users.Include(e => e.Edges).Include(h => h.Histories).ToArray());
                EatBox1.Items.AddRange(db.Elements.ToArray());
                EatBox2.Items.AddRange(db.Elements.ToArray());
                EatBox3.Items.AddRange(db.Elements.ToArray());
                EatBox4.Items.AddRange(db.Elements.ToArray());
                EatBox5.Items.AddRange(db.Elements.ToArray());
                EatBox6.Items.AddRange(db.Elements.ToArray());

            }

            NamelistBox.DisplayMember = "Name";
            EatBox1.DisplayMember = "Name";
            EatBox2.DisplayMember = "Name";
            EatBox3.DisplayMember = "Name";
            EatBox4.DisplayMember = "Name";
            EatBox5.DisplayMember = "Name";
            EatBox6.DisplayMember = "Name";


        }
        #region History Button
        private void Historybutton_Click(object sender, EventArgs e)
        {
            if (NamelistBox.SelectedItem == null)
            {
                MessageBox.Show("Выберите пользователя!");
                return;
            }
            User seluser = (User)NamelistBox.SelectedItem;
            if (seluser.Histories[0].firsttime)
            {
                MessageBox.Show("Покушайте хотя бы один раз!");
                return;
            }
            
           Size = new Size(276, 267);
            Top = 250;
            Left = 500;
            
            Panel historypanel = new Panel
            {
                Size = new Size(262, 230),
                Location = new Point(0)
                
            };
            
            Controls.Add(historypanel);
            historypanel.BringToFront();

            Button historybutton = new Button
            {
                Size = new Size(262, 30),
                Location = new Point(-1, 198),
                Text = "Закрыть историю"

            };
            historypanel.Controls.Add(historybutton);

            ListBox historylistbox = new ListBox
            {
                DisplayMember = "h.Key",
                Size = new Size(62, 200),
                Location = new Point(0)

            };
            historypanel.Controls.Add(historylistbox);

            TextBox historytextbox = new TextBox
            {
                Size = new Size(200, 199),
                Location = new Point(63, 0),
                Multiline = true,
                ScrollBars = ScrollBars.Both,
                TextAlign = HorizontalAlignment.Left,
                ReadOnly = true,
                BorderStyle = BorderStyle.Fixed3D


            };
            historypanel.Controls.Add(historytextbox);

            
            var Grouped = from history in seluser.Histories
                          group history by history.Date;
            foreach (IGrouping<DateTime, History> h in Grouped)
            {
                historylistbox.Items.Add(h);

            }
            List<string> lines = new List<string>();
            historybutton.Click += Closeclick;
            void Closeclick(object button, EventArgs click)
            {
                Size = new Size(890, 430);
                historypanel.Dispose();

            }
            historylistbox.SelectedIndexChanged += SelectDate;
            void SelectDate(object history, EventArgs click)
            {
                lines.Clear();

                foreach (IGrouping<DateTime, History> h in Grouped)
                {
                    if (h.Key.ToString() == historylistbox.Text)
                    {

                        foreach (var t in h)
                        {
                            lines.AddRange(new string[] { $"Прием пищи: {t.Countofeat} из {seluser.Edges.Numbereats}", $"Что покушали: { t.Foodname}", $"Углеводы: { t.CarboHydrates}  из { seluser.Edges.Carbohydrates}", $"Белки: {t.Proteins} из {seluser.Edges.Proteins}", $"Жиры: {t.Fats} из {seluser.Edges.Fats}", $"Каллории: {t.Callories} из {seluser.Edges.Calloriesedge}", "", "" });

                            historytextbox.Lines = lines.ToArray();
                        }
                    }

                }

            }

        }

        #endregion

        #region Food Selected
        private void EatBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox1.Focus();

            try
            {
                Energoelements element = (Energoelements)EatBox1.SelectedItem;
                Ugllabel1.Text = element.Carbohydrates;
                Bellabel1.Text = element.Protein;
                Jirlabel1.Text = element.Fats;
                Callabel1.Text = element.Callories;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox2.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox2.SelectedItem;
                Ugllabel2.Text = element.Carbohydrates;
                Bellabel2.Text = element.Protein;
                Jirlabel2.Text = element.Fats;
                Callabel2.Text = element.Callories;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox3.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox3.SelectedItem;
                Ugllabel3.Text = element.Carbohydrates;
                Bellabel3.Text = element.Protein;
                Jirlabel3.Text = element.Fats;
                Callabel3.Text = element.Callories;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox4.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox4.SelectedItem;
                Ugllabel4.Text = element.Carbohydrates;
                Bellabel4.Text = element.Protein;
                Jirlabel4.Text = element.Fats;
                Callabel4.Text = element.Callories;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            EatBox5.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox5.SelectedItem;
                Ugllabel5.Text = element.Carbohydrates;
                Bellabel5.Text = element.Protein;
                Jirlabel5.Text = element.Fats;
                Callabel5.Text = element.Callories;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }

        private void EatBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

            EatBox6.Focus();
            try
            {
                Energoelements element = (Energoelements)EatBox6.SelectedItem;
                Ugllabel6.Text = element.Carbohydrates;
                Bellabel6.Text = element.Protein;
                Jirlabel6.Text = element.Fats;
                Callabel6.Text = element.Callories;
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка в данных блюда! Проверьте правильность информации!");
            }
        }
        #endregion

        #region Eatclick
        private void Eatbutton_Click(object sender, EventArgs e)
        {
            if (NamelistBox.SelectedItem == null)
            {
                MessageBox.Show("Выберете пользователя или добавьте нового!");
                return;
            }
            else
            {
                if (AllUgllabel.Text != "0" || AllBellabel.Text != "0" || AllJirlabel.Text != "0" || AllCallabel.Text != "0")
                {
                    User seluser = (User)NamelistBox.SelectedItem;


                    if (DateTime.Now.Date != seluser.Histories.Last().Date && seluser.Histories.Last().firsttime == false)
                    {

                        History newhistory = new History { Date = DateTime.Now.Date, Countofeat = 1, UserId = seluser.Id, firsttime = false };
                        if (Convert.ToDecimal(AllUgllabel.Text) > Convert.ToDecimal(seluser.Edges.Carbohydrates))
                        {
                            MessageBox.Show("Вы превысили суточное потребление углеводов!");
                            return;
                        }
                        if (Convert.ToDecimal(AllBellabel.Text) > Convert.ToDecimal(seluser.Edges.Proteins))
                        {
                            MessageBox.Show("Вы превысили суточное протребление протеинов!");
                            return;
                        }
                        if (Convert.ToDecimal(AllJirlabel.Text) > Convert.ToDecimal(seluser.Edges.Fats))
                        {
                            MessageBox.Show("Вы превысили суточное потребление жиров!");
                            return;
                        }
                        if (Convert.ToDecimal(AllCallabel.Text) > Convert.ToDecimal(seluser.Edges.Calloriesedge))
                        {
                            MessageBox.Show("Вы превысили суточное потребление каллорий!");
                            return;
                        }
                        newhistory.CarboHydrates = AllUgllabel.Text;
                        newhistory.Proteins = AllBellabel.Text;
                        newhistory.Fats = AllJirlabel.Text;
                        newhistory.Callories = AllCallabel.Text;
                        if (EatBox1.SelectedItem != null)
                        {
                            newhistory.Foodname = EatBox1.Text;
                            if (EatBox2.SelectedItem != null || EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";
                        }
                        if (EatBox2.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox2.Text;
                            if (EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";

                        }
                        if (EatBox3.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox3.Text;
                            if (EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";

                        }
                        if (EatBox4.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox4.Text;
                            if (EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";

                        }
                        if (EatBox5.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox5.Text;
                            if (EatBox6.SelectedItem != null)
                            {
                                newhistory.Foodname += ",";
                                newhistory.Foodname += EatBox6.Text;

                            }

                        }
                        using (var db = new Aplicatincontext())
                        {
                            var checkid = db.Histories.ToList();
                            newhistory.Id = checkid.Last().Id + 1;

                            db.Histories.Add(newhistory);
                            db.SaveChanges();
                        }
                        seluser.Histories.Add(newhistory);
                        MessageBox.Show("Ням - Ням!");

                    }
                    else
                    {
                        History newhistory = new History { UserId = seluser.Id, Date = DateTime.Now.Date };

                        if (!seluser.Histories.Last().firsttime)
                        {
                            newhistory.Countofeat = seluser.Histories.Last().Countofeat + 1;
                            if (newhistory.Countofeat > seluser.Edges.Numbereats)
                            {
                                MessageBox.Show("Вы привысили количество приемов пищи!");
                                return;
                            }

                        }

                        decimal edgecarbo = Convert.ToDecimal(seluser.Histories.Last().CarboHydrates) + Convert.ToDecimal(AllUgllabel.Text);
                        if (edgecarbo > Convert.ToDecimal(seluser.Edges.Carbohydrates))
                        {
                            MessageBox.Show("Вы превысили суточное потребление углеводов!");
                            return;
                        }
                        decimal edgeprot = Convert.ToDecimal(seluser.Histories.Last().Proteins) + Convert.ToDecimal(AllBellabel.Text);
                        if (edgeprot > Convert.ToDecimal(seluser.Edges.Proteins))
                        {
                            MessageBox.Show("Вы превысили суточное протребление протеинов!");
                            return;
                        }
                        decimal edgefat = Convert.ToDecimal(seluser.Histories.Last().Fats) + Convert.ToDecimal(AllJirlabel.Text);
                        if (edgefat > Convert.ToDecimal(seluser.Edges.Fats))
                        {
                            MessageBox.Show("Вы превысили суточное потребление жиров!");
                            return;
                        }
                        decimal edgecall = Convert.ToDecimal(seluser.Histories.Last().Callories) + Convert.ToDecimal(AllCallabel.Text);
                        if (edgecall > Convert.ToDecimal(seluser.Edges.Calloriesedge))
                        {
                            MessageBox.Show("Вы превысили суточное потребление каллорий!");
                            return;
                        }
                        newhistory.CarboHydrates = $"{edgecarbo}";
                        newhistory.Proteins = $"{edgeprot}";
                        newhistory.Fats = $"{edgefat}";
                        newhistory.Callories = $"{edgecall}";

                        if (EatBox1.SelectedItem != null)
                        {
                            newhistory.Foodname = EatBox1.Text;
                            if (EatBox2.SelectedItem != null || EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";
                        }
                        if (EatBox2.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox2.Text;
                            if (EatBox3.SelectedItem != null || EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";

                        }
                        if (EatBox3.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox3.Text;
                            if (EatBox4.SelectedItem != null || EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";

                        }
                        if (EatBox4.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox4.Text;
                            if (EatBox5.SelectedItem != null || EatBox6.SelectedItem != null)
                                newhistory.Foodname += ",";

                        }
                        if (EatBox5.SelectedItem != null)
                        {
                            newhistory.Foodname += EatBox5.Text;
                            if (EatBox6.SelectedItem != null)
                            {
                                newhistory.Foodname += ",";
                                newhistory.Foodname += EatBox6.Text;

                            }

                        }
                        using (var db = new Aplicatincontext())
                        {
                            if (!seluser.Histories.Last().firsttime)
                            {
                                var checkid = db.Histories.ToList();
                                newhistory.Id = checkid.Last().Id + 1;
                            }
                            if (seluser.Histories.Last().firsttime)
                            {
                                newhistory.Countofeat = 1;
                                newhistory.firsttime = false;
                                newhistory.Id = seluser.Histories[0].Id;
                                seluser.Histories[0] = newhistory;
                                db.Histories.Update(newhistory);
                                db.SaveChanges();
                                MessageBox.Show("Ням - Ням!");
                                return;

                            }

                            db.Histories.Add(newhistory);
                            db.SaveChanges();
                        }
                        seluser.Histories.Add(newhistory);
                        MessageBox.Show("Ням - Ням!");
                    }

                }
                else
                {
                    MessageBox.Show("Выберите хотя бы одно блюдо!");
                    return;
                }


            }

        }
        #endregion

        #region Clear food
        private void ClearEatpictureBox1_Click(object sender, EventArgs e)
        {
            Ugllabel1.Text = "0";
            Bellabel1.Text = "0";
            Jirlabel1.Text = "0";
            Callabel1.Text = "0";
            EatBox1.Focus();
            EatBox1.SelectedText = "";
            MultiBox1.Text = "1";
            MultiBox1.Enabled = false;
        }

        private void ClearEatpictureBox2_Click(object sender, EventArgs e)
        {
            Ugllabel2.Text = "0";
            Bellabel2.Text = "0";
            Jirlabel2.Text = "0";
            Callabel2.Text = "0";
            EatBox2.Focus();
            EatBox2.SelectedText = "";
            MultiBox2.Text = "1";
            MultiBox2.Enabled = false;

        }

        private void ClearEatpictureBox3_Click(object sender, EventArgs e)
        {
            Ugllabel3.Text = "0";
            Bellabel3.Text = "0";
            Jirlabel3.Text = "0";
            Callabel3.Text = "0";
            EatBox3.Focus();
            EatBox3.SelectedText = "";
            MultiBox3.Text = "1";
            MultiBox3.Enabled = false;
        }

        private void ClearEatpictureBox4_Click(object sender, EventArgs e)
        {
            Ugllabel4.Text = "0";
            Bellabel4.Text = "0";
            Jirlabel4.Text = "0";
            Callabel4.Text = "0";
            EatBox4.Focus();
            EatBox4.SelectedText = "";
            MultiBox4.Text = "1";
            MultiBox4.Enabled = false;
        }

        private void ClearEatpictureBox5_Click(object sender, EventArgs e)
        {
            Ugllabel5.Text = "0";
            Bellabel5.Text = "0";
            Jirlabel5.Text = "0";
            Callabel5.Text = "0";
            EatBox5.Focus();
            EatBox5.SelectedText = "";
            MultiBox5.Text = "1";
            MultiBox5.Enabled = false;
        }

        private void ClearEatpictureBox6_Click(object sender, EventArgs e)
        {
            Ugllabel6.Text = "0";
            Bellabel6.Text = "0";
            Jirlabel6.Text = "0";
            Callabel6.Text = "0";
            EatBox6.Focus();
            EatBox6.SelectedText = "";
            MultiBox6.Text = "1";
            MultiBox6.Enabled = false;
        }
        #endregion

        #region Add Fodd
        private void AddEatpictureBox1_Click(object sender, EventArgs e)
        {
            EatBox1.Focus();
            Energoelements setel = (Energoelements)EatBox1.SelectedItem;
            if (EatBox1.SelectedItem == null)
                return;
            Ugllabel1.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel1.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel1.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel1.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            MultiBox1.Text = (Convert.ToDecimal(MultiBox1.Text) + 1).ToString();
        }

        private void AddEatpictureBox2_Click(object sender, EventArgs e)
        {
            EatBox2.Focus();
            Energoelements setel = (Energoelements)EatBox2.SelectedItem;

            if (EatBox2.SelectedItem == null)
                return;
            Ugllabel2.Text = (Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel2.Text = (Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel2.Text = (Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel2.Text = (Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            MultiBox2.Text = (Convert.ToDecimal(MultiBox2.Text) + 1).ToString();

        }

        private void AddEatpictureBox3_Click(object sender, EventArgs e)
        {
            EatBox3.Focus();
            Energoelements setel = (Energoelements)EatBox3.SelectedItem;

            if (EatBox3.SelectedItem == null)
                return;
            Ugllabel3.Text = (Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel3.Text = (Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel3.Text = (Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel3.Text = (Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            MultiBox3.Text = (Convert.ToDecimal(MultiBox3.Text) + 1).ToString();

        }

        private void AddEatpictureBox4_Click(object sender, EventArgs e)
        {
            EatBox4.Focus();
            Energoelements setel = (Energoelements)EatBox4.SelectedItem;

            if (EatBox4.SelectedItem == null)
                return;
            Ugllabel4.Text = (Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel4.Text = (Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel4.Text = (Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel4.Text = (Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            MultiBox4.Text = (Convert.ToDecimal(MultiBox4.Text) + 1).ToString();


        }

        private void AddEatpictureBox5_Click(object sender, EventArgs e)
        {
            EatBox5.Focus();
            Energoelements setel = (Energoelements)EatBox5.SelectedItem;

            if (EatBox5.SelectedItem == null)
                return;
            Ugllabel5.Text = (Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel5.Text = (Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel5.Text = (Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel5.Text = (Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            MultiBox5.Text = (Convert.ToDecimal(MultiBox5.Text) + 1).ToString();

        }

        private void AddEatpictureBox6_Click(object sender, EventArgs e)
        {
            EatBox6.Focus();
            Energoelements setel = (Energoelements)EatBox6.SelectedItem;

            if (EatBox6.SelectedItem == null)
                return;
            Ugllabel6.Text = (Convert.ToDecimal(Ugllabel6.Text) + Convert.ToDecimal(setel.Carbohydrates)).ToString();
            Bellabel6.Text = (Convert.ToDecimal(Bellabel6.Text) + Convert.ToDecimal(setel.Protein)).ToString();
            Jirlabel6.Text = (Convert.ToDecimal(Jirlabel6.Text) + Convert.ToDecimal(setel.Fats)).ToString();
            Callabel6.Text = (Convert.ToDecimal(Callabel6.Text) + Convert.ToDecimal(setel.Callories)).ToString();
            MultiBox6.Text = (Convert.ToDecimal(MultiBox6.Text) + 1).ToString();

        }
        #endregion

        #region User Button
        private void UserBut_Click(object sender, EventArgs e)
        {
            Size = new Size(890, 520);
            UserBut.Hide();
            FoodBut.Hide();
            ClearFoodBut.Enabled = false;
            Eatbutton.Enabled = false;
            Historybutton.Enabled = false;


            Panel UserFoodPan = new Panel
            {
                Size = new Size(490, 40),
                Location = new Point(288, 10)

            };
            Controls.Add(UserFoodPan);

            Button Addbutton = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(0),
                Text = "Добавить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),



            };
            UserFoodPan.Controls.Add(Addbutton);
            Addbutton.FlatAppearance.BorderColor = Color.Blue;
            Addbutton.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            Addbutton.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button UpdateBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(120),
                Text = "Редактировать",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),
            };
            UserFoodPan.Controls.Add(UpdateBut);
            UpdateBut.FlatAppearance.BorderColor = Color.Blue;
            UpdateBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            UpdateBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button DeleteUserBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(240),
                Text = "Удалить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),

            };
            UserFoodPan.Controls.Add(DeleteUserBut);
            DeleteUserBut.FlatAppearance.BorderColor = Color.Blue;
            DeleteUserBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            DeleteUserBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            Button CancelBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(360),
                Text = "Отмена",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),


            };
            UserFoodPan.Controls.Add(CancelBut);
            CancelBut.FlatAppearance.BorderColor = Color.Blue;
            CancelBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            CancelBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            #region Cancel Button
            CancelBut.Click += CancelButClick;
            void CancelButClick(object but, EventArgs click)
            {
                UserFoodPan.Dispose();
                ClearFoodBut.Enabled = true;
                Historybutton.Enabled = true;
                Eatbutton.Enabled = true;
                NamelistBox.Enabled = true;
                Size = new Size(890, 430);
                UserBut.Show();
                FoodBut.Show();
                if (Controls.ContainsKey("adduserpanel"))
                {
                    Controls.RemoveByKey("adduserpanel");
                }
                if (Controls.ContainsKey("upduserpanel"))
                {
                    Controls.RemoveByKey("upduserpanel");
                }

            }
            #endregion
            #region Add Click
            Addbutton.Click += AddClick;
            void AddClick(object but, EventArgs click)
            {
                if (Controls.ContainsKey("upduserpanel"))
                {
                    Controls.RemoveByKey("upduserpanel");

                }
                Addbutton.Enabled = false;
                UpdateBut.Enabled = true;
                DeleteUserBut.Enabled = true;
                NamelistBox.Enabled = false;



                Panel adduserpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.Aquamarine,
                    Location = new Point(11, 380),
                    Name = "adduserpanel"


                };
                Controls.Add(adduserpanel);


                Label addname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Имя",
                    AutoSize = true,


                };
                adduserpanel.Controls.Add(addname);
                addname.BringToFront();

                Label addcarbohyd = new Label
                {
                    Location = new Point(88, 10),
                    Text = "Макс. углеводов",
                    AutoSize = true
                };
                adduserpanel.Controls.Add(addcarbohyd);
                addcarbohyd.BringToFront();

                Label addproteins = new Label
                {
                    Location = new Point(203, 10),
                    Text = "Макс. протеинов",
                    AutoSize = true

                };
                adduserpanel.Controls.Add(addproteins);
                addproteins.BringToFront();

                Label addfats = new Label
                {
                    Location = new Point(312, 10),
                    Text = "Макс. жиров",
                    AutoSize = true

                };
                adduserpanel.Controls.Add(addfats);
                addfats.BringToFront();

                Label addcallories = new Label
                {
                    Location = new Point(407, 10),
                    Text = "Макс. каллорий",
                    AutoSize = true
                };
                adduserpanel.Controls.Add(addcallories);
                addcallories.BringToFront();

                Label addeat = new Label
                {
                    Location = new Point(520, 10),
                    Text = "Количество трапез",
                    AutoSize = true
                };
                adduserpanel.Controls.Add(addeat);
                addeat.BringToFront();

                TextBox namebox = new TextBox
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                adduserpanel.Controls.Add(namebox);
                namebox.BringToFront();

                TextBox carbohydbox = new TextBox
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(carbohydbox);
                carbohydbox.BringToFront();

                TextBox proteinbox = new TextBox
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(proteinbox);
                proteinbox.BringToFront();

                TextBox fatsbox = new TextBox
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(fatsbox);
                fatsbox.BringToFront();

                TextBox calloriesbox = new TextBox
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(calloriesbox);
                calloriesbox.BringToFront();

                TextBox numbereat = new TextBox
                {
                    Location = new Point(555, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                adduserpanel.Controls.Add(numbereat);
                numbereat.BringToFront();

                Button adduserbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Добавить"
                };
                adduserpanel.Controls.Add(adduserbut);
                adduserbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                adduserpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();
                

                #region Add User Click

                adduserbut.Click += AddUserClick;
                void AddUserClick(object but, EventArgs click)
                {
                    if (namebox.Text != "" && carbohydbox.Text != "" && proteinbox.Text != "" && fatsbox.Text != "" && calloriesbox.Text != "" && numbereat.Text != "")
                    {
                        try
                        {
                            User newuser = new User { Name = namebox.Text };
                            Edgeelements edgeelements = new Edgeelements { Calloriesedge = calloriesbox.Text, Carbohydrates = (carbohydbox.Text), Fats = (fatsbox.Text), Proteins = (proteinbox.Text), Numbereats = Convert.ToInt32(numbereat.Text), user = newuser };
                            History newhistory = new History { UserId = newuser.Id, user = newuser, CarboHydrates = "0", Proteins = "0", Fats = "0", Callories = "0", Countofeat = 0, firsttime = true };
                            MessageBox.Show("Пользователь успешно добавлен");

                            NamelistBox.Items.Add(newuser);

                            using (var db = new Aplicatincontext())
                            {
                                db.Users.Add(newuser);
                                db.Edges.Add(edgeelements);
                                db.Histories.Add(newhistory);
                                db.SaveChanges();
                            }


                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильное значение");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");

                    }
                    adduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;
                    NamelistBox.Enabled = true;

                }
                #endregion
                #region Cancel But

                cancelbut.Click += CancelAddUserClick;
                void CancelAddUserClick(object but, EventArgs click)
                {
                    adduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;
                    NamelistBox.Enabled = true;

                }
                #endregion

            }
            #endregion
            #region UpdateUser

            UpdateBut.Click += UpdateButClick;
            void UpdateButClick(object but, EventArgs click)
            {
                if (NamelistBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберете пользователя!");
                    return;
                }
                if (Controls.ContainsKey("adduserpanel"))
                {
                    Controls.RemoveByKey("adduserpanel");

                }

                Addbutton.Enabled = true;
                UpdateBut.Enabled = false;
                DeleteUserBut.Enabled = true;
                NamelistBox.Enabled = false;

                Panel upduserpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.CornflowerBlue,
                    Location = new Point(11, 380),
                    Name = "upduserpanel"

                };
                Controls.Add(upduserpanel);


                Label updname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Имя",
                    AutoSize = true,

                };
                upduserpanel.Controls.Add(updname);
                updname.BringToFront();

                Label updcarbohyd = new Label
                {
                    Location = new Point(88, 10),
                    Text = "Макс. углеводов",
                    AutoSize = true
                };
                upduserpanel.Controls.Add(updcarbohyd);
                updcarbohyd.BringToFront();

                Label updproteins = new Label
                {
                    Location = new Point(203, 10),
                    Text = "Макс. протеинов",
                    AutoSize = true

                };
                upduserpanel.Controls.Add(updproteins);
                updproteins.BringToFront();

                Label updfats = new Label
                {
                    Location = new Point(312, 10),
                    Text = "Макс. жиров",
                    AutoSize = true

                };
                upduserpanel.Controls.Add(updfats);
                updfats.BringToFront();

                Label updcallories = new Label
                {
                    Location = new Point(407, 10),
                    Text = "Макс. каллорий",
                    AutoSize = true
                };
                upduserpanel.Controls.Add(updcallories);
                updcallories.BringToFront();

                Label updeat = new Label
                {
                    Location = new Point(520, 10),
                    Text = "Количество трапез",
                    AutoSize = true
                };
                upduserpanel.Controls.Add(updeat);
                updeat.BringToFront();

                TextBox namebox = new TextBox
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                upduserpanel.Controls.Add(namebox);
                namebox.BringToFront();

                TextBox carbohydbox = new TextBox
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(carbohydbox);
                carbohydbox.BringToFront(); 

                TextBox proteinbox = new TextBox
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(proteinbox);
                proteinbox.BringToFront();

                TextBox fatsbox = new TextBox
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(fatsbox);
                fatsbox.BringToFront();

                TextBox calloriesbox = new TextBox
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(calloriesbox);
                calloriesbox.BringToFront();

                TextBox numbereat = new TextBox
                {
                    Location = new Point(555, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                upduserpanel.Controls.Add(numbereat);
                numbereat.BringToFront();

                Button upduserbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Обновить"
                };
                upduserpanel.Controls.Add(upduserbut);
                upduserbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                upduserpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();

                #region Cancel But

                void Clickcancelbut(object cancel, EventArgs cliclcancel)
                {
                    upduserpanel.Dispose();
                    Addbutton.Enabled = true;
                    DeleteUserBut.Enabled = true;
                    UpdateBut.Enabled = true;
                    NamelistBox.Enabled = true;
                }
                cancelbut.Click += Clickcancelbut;
                #endregion
                #region Update Click

                void Clickbut(object button, EventArgs click)
                {
                    if (namebox.Text != "" && carbohydbox.Text != "" && proteinbox.Text != "" && fatsbox.Text != "" && calloriesbox.Text != "" && numbereat.Text != "")
                    {
                        try
                        {
                            User newuser = (User)NamelistBox.SelectedItem;
                            newuser.Name = namebox.Text;
                            newuser.Edges.Carbohydrates = carbohydbox.Text;
                            newuser.Edges.Calloriesedge = calloriesbox.Text;
                            newuser.Edges.Fats = fatsbox.Text;
                            newuser.Edges.Proteins = proteinbox.Text;
                            newuser.Edges.Numbereats = Convert.ToInt32(numbereat.Text);

                            using (var db = new Aplicatincontext())
                            {
                                db.Users.Update(newuser);
                                db.Edges.Update(newuser.Edges);
                                db.SaveChanges();
                            }
                            NamelistBox.Items.Remove(NamelistBox.SelectedItem);
                            NamelistBox.Items.Add(newuser);
                            upduserpanel.Dispose();
                            Addbutton.Enabled = true;
                            DeleteUserBut.Enabled = true;
                            UpdateBut.Enabled = true;

                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Неправильное значение");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Заполните все поля!");

                    }
                    


                }

                upduserbut.Click += new EventHandler(Clickbut);
                #endregion
            }
            #endregion
            #region Delete But

            DeleteUserBut.Click += DeleteUserButClick;
            void DeleteUserButClick(object but, EventArgs click)
            {
                DeleteUserBut.Enabled = true;
                Addbutton.Enabled = true;
                UpdateBut.Enabled = true;
                NamelistBox.Enabled = true;
                if (NamelistBox.SelectedItem != null)
                {
                    User seluser = (User)NamelistBox.SelectedItem;
                    using (var db = new Aplicatincontext())
                    {
                        db.Histories.RemoveRange(seluser.Histories);
                        db.Edges.Remove(seluser.Edges);
                        db.Users.Remove(seluser);

                        db.SaveChanges();
                    }
                    NamelistBox.Items.Remove(seluser);
                }
                else { MessageBox.Show("Выберите пользователя!"); }
                return;
            }
            #endregion
        }
        #endregion

        #region Food Button
        private void FoodBut_Click(object sender, EventArgs e)
        {
            Size = new Size(890, 520);
            UserBut.Hide();
            FoodBut.Hide();
            ClearFoodBut.Enabled = false;
            Eatbutton.Enabled = false;
            Historybutton.Enabled = false;


            Panel UserFoodPan = new Panel
            {
                Size = new Size(490, 40),
                Location = new Point(288, 10)

            };
            Controls.Add(UserFoodPan);

            Button AddFoodBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(0),
                Text = "Добавить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),
            };
            UserFoodPan.Controls.Add(AddFoodBut);
            AddFoodBut.FlatAppearance.BorderColor = Color.Blue;
            AddFoodBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            AddFoodBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button UpdateFoodBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(120),
                Text = "Редактировать",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),
            };
            UserFoodPan.Controls.Add(UpdateFoodBut);
            UpdateFoodBut.FlatAppearance.BorderColor = Color.Blue;
            UpdateFoodBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            UpdateFoodBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));



            Button DeleteFoodBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(240),
                Text = "Удалить",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),

            };
            UserFoodPan.Controls.Add(DeleteFoodBut);
            DeleteFoodBut.FlatAppearance.BorderColor = Color.Blue;
            DeleteFoodBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            DeleteFoodBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));


            Button CancelBut = new Button
            {
                Size = new Size(115, 40),
                Location = new Point(360),
                Text = "Отмена",
                FlatStyle = FlatStyle.Flat,
                BackColor = SystemColors.GradientActiveCaption,
                Cursor = Cursors.Hand,
                Font = new Font("Segoe Script", 8F, FontStyle.Bold, GraphicsUnit.Point),
                Margin = new Padding(0),


            };
            UserFoodPan.Controls.Add(CancelBut);
            CancelBut.FlatAppearance.BorderColor = Color.Blue;
            CancelBut.FlatAppearance.MouseDownBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            CancelBut.FlatAppearance.MouseOverBackColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));

            #region Add Food Click

            AddFoodBut.Click += AddFoodButClick;
            void AddFoodButClick(object but, EventArgs click)
            {
                if (Controls.ContainsKey("updfoodpanel"))
                {
                    Controls.RemoveByKey("updfoodpanel");

                }
                if (Controls.ContainsKey("delfoodpanel"))
                {
                    Controls.RemoveByKey("delfoodpanel");
                }
                AddFoodBut.Enabled = false;
                UpdateFoodBut.Enabled = true;
                DeleteFoodBut.Enabled = true;



                Panel addfoodpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.GreenYellow,
                    Location = new Point(11, 380),
                    Name = "addfoodpanel"


                };
                Controls.Add(addfoodpanel);


                Label addname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Название",
                    AutoSize = true,


                };
                addfoodpanel.Controls.Add(addname);
                addname.BringToFront();

                Label addcarbohyd = new Label
                {
                    Location = new Point(88, 10),
                    Text = "Углеводы",
                    AutoSize = true
                };
                addfoodpanel.Controls.Add(addcarbohyd);
                addcarbohyd.BringToFront();

                Label addproteins = new Label
                {
                    Location = new Point(203, 10),
                    Text = "Белки",
                    AutoSize = true

                };
                addfoodpanel.Controls.Add(addproteins);
                addproteins.BringToFront();

                Label addfats = new Label
                {
                    Location = new Point(312, 10),
                    Text = "Жиры",
                    AutoSize = true

                };
                addfoodpanel.Controls.Add(addfats);
                addfats.BringToFront();

                Label addcallories = new Label
                {
                    Location = new Point(407, 10),
                    Text = "Каллории",
                    AutoSize = true
                };
                addfoodpanel.Controls.Add(addcallories);
                addcallories.BringToFront();


                TextBox namebox = new TextBox
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                addfoodpanel.Controls.Add(namebox);
                namebox.BringToFront();

                TextBox carbohydbox = new TextBox
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                addfoodpanel.Controls.Add(carbohydbox);
                carbohydbox.BringToFront();

                TextBox proteinbox = new TextBox
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                addfoodpanel.Controls.Add(proteinbox);
                proteinbox.BringToFront();

                TextBox fatsbox = new TextBox
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                addfoodpanel.Controls.Add(fatsbox);
                fatsbox.BringToFront();

                TextBox calloriesbox = new TextBox
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                addfoodpanel.Controls.Add(calloriesbox);
                calloriesbox.BringToFront();


                Button addfoodbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Добавить"
                };
                addfoodpanel.Controls.Add(addfoodbut);
                addfoodbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                addfoodpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();
                

                #region Add Click

                addfoodbut.Click += addfoodbutClick;
                void addfoodbutClick(object but, EventArgs click)
                {
                    try
                    {
                        Energoelements newelement = new Energoelements { Name = namebox.Text, Carbohydrates = carbohydbox.Text, Protein = proteinbox.Text, Fats = fatsbox.Text, Callories = calloriesbox.Text };
                        if (namebox.Text != "" && carbohydbox.Text != "" && proteinbox.Text != "" && fatsbox.Text != "" && calloriesbox.Text != "")
                        {
                            using (var db = new Aplicatincontext())
                            {
                                db.Elements.Add(newelement);
                                db.SaveChanges();

                            }
                            EatBox1.Items.Add(newelement);
                            EatBox2.Items.Add(newelement);
                            EatBox3.Items.Add(newelement);
                            EatBox4.Items.Add(newelement);
                            EatBox5.Items.Add(newelement);
                            EatBox6.Items.Add(newelement);

                            MessageBox.Show("Блюдо успешно добавлено!");
                            addfoodpanel.Dispose();
                            AddFoodBut.Enabled = true;
                            DeleteFoodBut.Enabled = true;
                            UpdateFoodBut.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Введите все значения!");
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Неправильное значение!");
                    }
                }

                #endregion
                #region Cancel But

                cancelbut.Click += cancelbutClick;
                void cancelbutClick(object but, EventArgs click)
                {
                    addfoodpanel.Dispose();
                    AddFoodBut.Enabled = true;
                    DeleteFoodBut.Enabled = true;
                    UpdateFoodBut.Enabled = true;
                }
                #endregion
            }
            #endregion
            #region Update Button

            UpdateFoodBut.Click += UpdFoodButClick;
            void UpdFoodButClick(object but, EventArgs click)
            {
                if (Controls.ContainsKey("addfoodpanel"))
                {
                    Controls.RemoveByKey("addfoodpanel");

                }
                if (Controls.ContainsKey("delfoodpanel"))
                {
                    Controls.RemoveByKey("delfoodpanel");
                }
                AddFoodBut.Enabled = true;
                UpdateFoodBut.Enabled = false;
                DeleteFoodBut.Enabled = true;



                Panel updfoodpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.PaleVioletRed,
                    Location = new Point(11, 380),
                    Name = "updfoodpanel"
                };
                Controls.Add(updfoodpanel);
                Label updname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Название",
                    AutoSize = true,


                };
                updfoodpanel.Controls.Add(updname);
                updname.BringToFront();

                Label updcarbohyd = new Label
                {
                    Location = new Point(108, 10),
                    Text = "Углеводы",
                    AutoSize = true
                };
                updfoodpanel.Controls.Add(updcarbohyd);
                updcarbohyd.BringToFront();

                Label updproteins = new Label
                {
                    Location = new Point(228, 10),
                    Text = "Белки",
                    AutoSize = true

                };
                updfoodpanel.Controls.Add(updproteins);
                updproteins.BringToFront();

                Label updfats = new Label
                {
                    Location = new Point(337, 10),
                    Text = "Жиры",
                    AutoSize = true

                };
                updfoodpanel.Controls.Add(updfats);
                updfats.BringToFront();

                Label updcallories = new Label
                {
                    Location = new Point(427, 10),
                    Text = "Каллории",
                    AutoSize = true
                };
                updfoodpanel.Controls.Add(updcallories);
                updcallories.BringToFront();


                TextBox namebox = new TextBox
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                updfoodpanel.Controls.Add(namebox);
                namebox.BringToFront();

                TextBox carbohydbox = new TextBox
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                updfoodpanel.Controls.Add(carbohydbox);
                carbohydbox.BringToFront();

                TextBox proteinbox = new TextBox
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                updfoodpanel.Controls.Add(proteinbox);
                proteinbox.BringToFront();

                TextBox fatsbox = new TextBox
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                updfoodpanel.Controls.Add(fatsbox);
                fatsbox.BringToFront();

                TextBox calloriesbox = new TextBox
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                updfoodpanel.Controls.Add(calloriesbox);
                calloriesbox.BringToFront();

                ComboBox updfoodcombobox = new ComboBox
                {
                    Size = new Size(100, 20),
                    DropDownStyle = ComboBoxStyle.DropDown,
                    Location = new Point(510, 30),
                    DisplayMember = "Name"
                };
                updfoodpanel.Controls.Add(updfoodcombobox);

                Button updfoodbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Принять"
                };
                updfoodpanel.Controls.Add(updfoodbut);
                updfoodbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                updfoodpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();

                using (var db = new Aplicatincontext())
                {
                    updfoodcombobox.Items.AddRange(db.Elements.ToArray());

                }
                updfoodcombobox.SelectedIndexChanged += updfoodcomboboxchanged;

                #region Select Food

                void updfoodcomboboxchanged(object box, EventArgs changed)
                {
                    Energoelements updelement = (Energoelements)updfoodcombobox.SelectedItem;
                    namebox.Text = updelement.Name;
                    carbohydbox.Text = updelement.Carbohydrates;
                    proteinbox.Text = updelement.Protein;
                    fatsbox.Text = updelement.Fats;
                    calloriesbox.Text = updelement.Callories;

                }
                #endregion

                #region Cancel But

                cancelbut.Click += cancelbutClick;
                void cancelbutClick(object but, EventArgs click)
                {
                    updfoodpanel.Dispose();
                    UpdateFoodBut.Enabled = true;

                }
                #endregion
                #region Update Click Button

                updfoodbut.Click += updfoodbutClick;
                void updfoodbutClick(object but, EventArgs click)
                {

                    if (updfoodcombobox.SelectedItem != null)
                    {
                        Energoelements updelement = (Energoelements)updfoodcombobox.SelectedItem;
                        if (namebox.Text != "")
                            updelement.Name = namebox.Text;
                        if (carbohydbox.Text != "")
                            updelement.Carbohydrates = carbohydbox.Text;
                        if (proteinbox.Text != "")
                            updelement.Protein = proteinbox.Text;
                        if (fatsbox.Text != "")
                            updelement.Fats = fatsbox.Text;
                        if (calloriesbox.Text != "")
                            updelement.Callories = calloriesbox.Text;
                        using (var db = new Aplicatincontext())
                        {
                            db.Elements.Update(updelement);
                            db.SaveChanges();
                        }
                        EatBox1.Items.RemoveAt(updfoodcombobox.SelectedIndex);
                        EatBox2.Items.RemoveAt(updfoodcombobox.SelectedIndex);
                        EatBox3.Items.RemoveAt(updfoodcombobox.SelectedIndex);
                        EatBox4.Items.RemoveAt(updfoodcombobox.SelectedIndex);
                        EatBox5.Items.RemoveAt(updfoodcombobox.SelectedIndex);
                        EatBox6.Items.RemoveAt(updfoodcombobox.SelectedIndex);
                        updfoodcombobox.Items.Remove(updfoodcombobox.SelectedItem);
                        EatBox1.Items.Add(updelement);
                        EatBox2.Items.Add(updelement);
                        EatBox3.Items.Add(updelement);
                        EatBox4.Items.Add(updelement);
                        EatBox5.Items.Add(updelement);
                        EatBox6.Items.Add(updelement);
                        updfoodcombobox.Items.Add(updelement);

                    }
                    else
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                }
                #endregion

            }
            #endregion
            #region Delete Food Click

            DeleteFoodBut.Click += DeleteFoodButClick;
            void DeleteFoodButClick(object but, EventArgs click)
            {
                DeleteFoodBut.Enabled = false;
                if (Controls.ContainsKey("addfoodpanel"))
                {
                    Controls.RemoveByKey("addfoodpanel");

                }
                if (Controls.ContainsKey("updfoodpanel"))
                {
                    Controls.RemoveByKey("updfoodpanel");
                }
                AddFoodBut.Enabled = true;
                UpdateFoodBut.Enabled = true;


                Panel delfoodpanel = new Panel
                {
                    Size = new Size(635, 95),
                    BackColor = Color.Turquoise,
                    Location = new Point(11, 380),
                    Name = "delfoodpanel"
                };
                Controls.Add(delfoodpanel);
                Label delname = new Label
                {

                    Location = new Point(8, 10),
                    Text = "Название",
                    AutoSize = true,

                };
                delfoodpanel.Controls.Add(delname);
                delname.BringToFront();

                Label delcarbohyd = new Label
                {
                    Location = new Point(108, 10),
                    Text = "Углеводы",
                    AutoSize = true
                };
                delfoodpanel.Controls.Add(delcarbohyd);
                delcarbohyd.BringToFront();

                Label delproteins = new Label
                {
                    Location = new Point(228, 10),
                    Text = "Белки",
                    AutoSize = true

                };
                delfoodpanel.Controls.Add(delproteins);
                delproteins.BringToFront();

                Label delfats = new Label
                {
                    Location = new Point(337, 10),
                    Text = "Жиры",
                    AutoSize = true

                };
                delfoodpanel.Controls.Add(delfats);
                delfats.BringToFront();

                Label delcallories = new Label
                {
                    Location = new Point(427, 10),
                    Text = "Каллории",
                    AutoSize = true
                };
                delfoodpanel.Controls.Add(delcallories);
                delcallories.BringToFront();


                Label name = new Label
                {
                    Location = new Point(10, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(60, 20)
                };
                delfoodpanel.Controls.Add(name);
                name.BringToFront();

                Label carbohyd = new Label
                {
                    Location = new Point(117, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                delfoodpanel.Controls.Add(carbohyd);
                carbohyd.BringToFront();

                Label protein = new Label
                {
                    Location = new Point(230, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                delfoodpanel.Controls.Add(protein);
                protein.BringToFront();

                Label fats = new Label
                {
                    Location = new Point(337, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                delfoodpanel.Controls.Add(fats);
                fats.BringToFront();

                Label callories = new Label
                {
                    Location = new Point(437, 30),
                    Font = new Font(FontFamily.GenericSansSerif, 8),
                    Size = new Size(40, 20)
                };
                delfoodpanel.Controls.Add(callories);
                callories.BringToFront();

                ComboBox delfoodcombobox = new ComboBox
                {
                    Size = new Size(100, 20),
                    DropDownStyle = ComboBoxStyle.DropDown,
                    Location = new Point(510, 30),
                    DisplayMember = "Name"
                };
                delfoodpanel.Controls.Add(delfoodcombobox);

                Button delfoodbut = new Button
                {
                    Location = new Point(229, 55),
                    Text = "Удалить"
                };
                delfoodpanel.Controls.Add(delfoodbut);
                delfoodbut.BringToFront();

                Button cancelbut = new Button
                {
                    Location = new Point(336, 55),
                    Text = "Отмена"
                };
                delfoodpanel.Controls.Add(cancelbut);
                cancelbut.BringToFront();

                using (var db = new Aplicatincontext())
                {
                    delfoodcombobox.Items.AddRange(db.Elements.ToArray());

                }
                delfoodcombobox.SelectedIndexChanged += delfoodcomboboxchanged;

                //Функционал выбора блюда

                void delfoodcomboboxchanged(object box, EventArgs changed)
                {
                    Energoelements delelement = (Energoelements)delfoodcombobox.SelectedItem;
                    name.Text = delelement.Name;
                    carbohyd.Text = delelement.Carbohydrates;
                    protein.Text = delelement.Protein;
                    fats.Text = delelement.Fats;
                    callories.Text = delelement.Callories;

                }

                //Функционал кнопки удалить

                delfoodbut.Click += delfoodbutClick;
                void delfoodbutClick(object but, EventArgs click)
                {
                    if (delfoodcombobox.SelectedItem != null)
                    {
                        Energoelements delelement = (Energoelements)delfoodcombobox.SelectedItem;
                        using (var db = new Aplicatincontext())
                        {
                            db.Elements.Remove(delelement);
                            db.SaveChanges();
                        }


                        EatBox1.Items.RemoveAt(delfoodcombobox.SelectedIndex);
                        EatBox2.Items.RemoveAt(delfoodcombobox.SelectedIndex);
                        EatBox3.Items.RemoveAt(delfoodcombobox.SelectedIndex);
                        EatBox4.Items.RemoveAt(delfoodcombobox.SelectedIndex);
                        EatBox5.Items.RemoveAt(delfoodcombobox.SelectedIndex);
                        EatBox6.Items.RemoveAt(delfoodcombobox.SelectedIndex);
                        delfoodcombobox.Items.Remove(delelement);
                        delfoodcombobox.Text = "";
                        name.Text = "";
                        carbohyd.Text = "";
                        protein.Text = "";
                        fats.Text = "";
                        callories.Text = "";
                        MessageBox.Show("Блюдо удалено!");


                    }
                    else
                    {
                        MessageBox.Show("Выберите блюдо!");
                    }
                }

                //Функционал кнопки отмена

                cancelbut.Click += cancelbutClick;
                void cancelbutClick(object but, EventArgs click)
                {
                    delfoodpanel.Dispose();
                    DeleteFoodBut.Enabled = true;
                }

            }
            #endregion
            #region Cancel But

            CancelBut.Click += CancelButClick;
            void CancelButClick(object but, EventArgs click)
            {
                UserFoodPan.Dispose();
                ClearFoodBut.Enabled = true;
                Historybutton.Enabled = true;
                Eatbutton.Enabled = true;
                NamelistBox.Enabled = true;
                Size = new Size(890, 430);
                UserBut.Show();
                FoodBut.Show();
                if (Controls.ContainsKey("addfoodpanel"))
                {
                    Controls.RemoveByKey("addfoodpanel");
                }
                if (Controls.ContainsKey("updfoodpanel"))
                {
                    Controls.RemoveByKey("updfoodpanel");
                }
                if (Controls.ContainsKey("delfoodpanel"))
                {
                    Controls.RemoveByKey("delfoodpanel");
                }

            }
            #endregion

        }
        #endregion

        #region ClearAll Button
        private void ClearFoodBut_Click(object sender, EventArgs e)
        {
            EatBox1.Text = "";
            EatBox2.Text = "";
            EatBox3.Text = "";
            EatBox4.Text = "";
            EatBox5.Text = "";
            EatBox6.Text = "";
            Ugllabel1.Text = "0";
            Bellabel1.Text = "0";
            Jirlabel1.Text = "0";
            Callabel1.Text = "0";
            Ugllabel2.Text = "0";
            Bellabel2.Text = "0";
            Jirlabel2.Text = "0";
            Callabel2.Text = "0";
            Ugllabel3.Text = "0";
            Bellabel3.Text = "0";
            Jirlabel3.Text = "0";
            Callabel3.Text = "0";
            Ugllabel4.Text = "0";
            Bellabel4.Text = "0";
            Jirlabel4.Text = "0";
            Callabel4.Text = "0";
            Ugllabel5.Text = "0";
            Bellabel5.Text = "0";
            Jirlabel5.Text = "0";
            Callabel5.Text = "0";
            Ugllabel6.Text = "0";
            Bellabel6.Text = "0";
            Jirlabel6.Text = "0";
            Callabel6.Text = "0";
            MultiBox1.Text = "1";
            MultiBox2.Text = "1";
            MultiBox3.Text = "1";
            MultiBox4.Text = "1";
            MultiBox5.Text = "1";
            MultiBox6.Text = "1";
            MultiBox1.Enabled = false;
            MultiBox2.Enabled = false;
            MultiBox3.Enabled = false;
            MultiBox4.Enabled = false;
            MultiBox5.Enabled = false;
            MultiBox6.Enabled = false;
        }
        #endregion

        #region Multiply Buttons
        private void Multipicture1_Click(object sender, EventArgs e)
        {
            if (EatBox1.SelectedItem != null)
            {
                if (!MultiBox1.Enabled)
                {

                    MultiBox1.Enabled = true;
                }

                else
                {
                    MultiBox1.Text = "1";
                    MultiBox1.Enabled = false;
                }
            }

        }

        private void Multipicture2_Click(object sender, EventArgs e)
        {
            if (!MultiBox2.Enabled)
                MultiBox2.Enabled = true;
            else
            {
                MultiBox2.Text = "1";
                MultiBox2.Enabled = false;
            }
        }

        private void Multipicture3_Click(object sender, EventArgs e)
        {
            if (!MultiBox3.Enabled)
                MultiBox3.Enabled = true;
            else
            {
                MultiBox3.Text = "1";
                MultiBox3.Enabled = false;
            }
        }

        private void Multipicture4_Click(object sender, EventArgs e)
        {
            if (!MultiBox4.Enabled)
                MultiBox4.Enabled = true;
            else
            {
                MultiBox4.Text = "1";
                MultiBox4.Enabled = false;
            }
        }

        private void Multipicture5_Click(object sender, EventArgs e)
        {
            if (!MultiBox5.Enabled)
                MultiBox5.Enabled = true;
            else
            {
                MultiBox5.Text = "1";
                MultiBox5.Enabled = false;
            }
        }

        private void Multipicture6_Click(object sender, EventArgs e)
        {
            if (!MultiBox6.Enabled)
                MultiBox6.Enabled = true;
            else
            {
                MultiBox6.Text = "1";
                MultiBox6.Enabled = false;
            }
        }
        #endregion

        #region Multiply TextBox
        private void MultiBox1_TextChanged(object sender, EventArgs e)
        {
            Energoelements setel = (Energoelements)(EatBox1.SelectedItem);
            if(EatBox1.Text=="")
            {
                return;
            }
            try
            {
                if (Convert.ToDecimal(MultiBox1.Text) >= 0)
                {
                    Ugllabel1.Text = (Convert.ToDecimal(setel.Carbohydrates) * Convert.ToDecimal(MultiBox1.Text)).ToString();
                    Bellabel1.Text = (Convert.ToDecimal(setel.Protein) * Convert.ToDecimal(MultiBox1.Text)).ToString();
                    Jirlabel1.Text = (Convert.ToDecimal(setel.Fats) * Convert.ToDecimal(MultiBox1.Text)).ToString();
                    Callabel1.Text = (Convert.ToDecimal(setel.Callories) * Convert.ToDecimal(MultiBox1.Text)).ToString();
                }
            }
            catch (Exception)
            {
                if (MultiBox1.Text == "")
                {
                    Ugllabel1.Text = setel.Carbohydrates;
                    Bellabel1.Text = setel.Protein;
                    Jirlabel1.Text = setel.Fats;
                    Callabel1.Text = setel.Callories;

                }
            }
        }
        private void MultiBox2_TextChanged(object sender, EventArgs e)
        {
            Energoelements setel = (Energoelements)(EatBox2.SelectedItem);
            if (EatBox2.Text == "")
            {
                return;
            }
            try
            {
                if (Convert.ToDecimal(MultiBox2.Text) >= 0)
                {
                    Ugllabel2.Text = (Convert.ToDecimal(setel.Carbohydrates) * Convert.ToDecimal(MultiBox2.Text)).ToString();
                    Bellabel2.Text = (Convert.ToDecimal(setel.Protein) * Convert.ToDecimal(MultiBox2.Text)).ToString();
                    Jirlabel2.Text = (Convert.ToDecimal(setel.Fats) * Convert.ToDecimal(MultiBox2.Text)).ToString();
                    Callabel2.Text = (Convert.ToDecimal(setel.Callories) * Convert.ToDecimal(MultiBox2.Text)).ToString();
                }
            }
            catch (Exception)
            {
                if (MultiBox2.Text == "")
                {
                    Ugllabel2.Text = setel.Carbohydrates;
                    Bellabel2.Text = setel.Protein;
                    Jirlabel2.Text = setel.Fats;
                    Callabel2.Text = setel.Callories;

                }
            }
        }
        private void MultiBox3_TextChanged(object sender, EventArgs e)
        {
            Energoelements setel = (Energoelements)(EatBox3.SelectedItem);
            if (EatBox3.Text == "")
            {
                return;
            }
            try
            {
                if (Convert.ToDecimal(MultiBox3.Text) >= 0)
                {
                    Ugllabel3.Text = (Convert.ToDecimal(setel.Carbohydrates) * Convert.ToDecimal(MultiBox3.Text)).ToString();
                    Bellabel3.Text = (Convert.ToDecimal(setel.Protein) * Convert.ToDecimal(MultiBox3.Text)).ToString();
                    Jirlabel3.Text = (Convert.ToDecimal(setel.Fats) * Convert.ToDecimal(MultiBox3.Text)).ToString();
                    Callabel3.Text = (Convert.ToDecimal(setel.Callories) * Convert.ToDecimal(MultiBox3.Text)).ToString();
                }
            }
            catch (Exception)
            {
                if (MultiBox3.Text == "")
                {
                    Ugllabel3.Text = setel.Carbohydrates;
                    Bellabel3.Text = setel.Protein;
                    Jirlabel3.Text = setel.Fats;
                    Callabel3.Text = setel.Callories;

                }
            }
        }
        private void MultiBox4_TextChanged(object sender, EventArgs e)
        {
            Energoelements setel = (Energoelements)(EatBox4.SelectedItem);
            if (EatBox4.Text == "")
            {
                return;
            }
            try
            {
                if (Convert.ToDecimal(MultiBox4.Text) >= 0)
                {
                    Ugllabel4.Text = (Convert.ToDecimal(setel.Carbohydrates) * Convert.ToDecimal(MultiBox4.Text)).ToString();
                    Bellabel4.Text = (Convert.ToDecimal(setel.Protein) * Convert.ToDecimal(MultiBox4.Text)).ToString();
                    Jirlabel4.Text = (Convert.ToDecimal(setel.Fats) * Convert.ToDecimal(MultiBox4.Text)).ToString();
                    Callabel4.Text = (Convert.ToDecimal(setel.Callories) * Convert.ToDecimal(MultiBox4.Text)).ToString();
                }
            }
            catch (Exception)
            {
                if (MultiBox4.Text == "")
                {
                    Ugllabel4.Text = setel.Carbohydrates;
                    Bellabel4.Text = setel.Protein;
                    Jirlabel4.Text = setel.Fats;
                    Callabel4.Text = setel.Callories;

                }
            }
        }
        private void MultiBox5_TextChanged(object sender, EventArgs e)
        {
            Energoelements setel = (Energoelements)(EatBox5.SelectedItem);
            if (EatBox5.Text == "")
            {
                return;
            }
            try
            {
                if (Convert.ToDecimal(MultiBox5.Text) >= 0)
                {
                    Ugllabel5.Text = (Convert.ToDecimal(setel.Carbohydrates) * Convert.ToDecimal(MultiBox5.Text)).ToString();
                    Bellabel5.Text = (Convert.ToDecimal(setel.Protein) * Convert.ToDecimal(MultiBox5.Text)).ToString();
                    Jirlabel5.Text = (Convert.ToDecimal(setel.Fats) * Convert.ToDecimal(MultiBox5.Text)).ToString();
                    Callabel5.Text = (Convert.ToDecimal(setel.Callories) * Convert.ToDecimal(MultiBox5.Text)).ToString();
                }
            }
            catch (Exception)
            {
                if (MultiBox5.Text == "")
                {
                    Ugllabel5.Text = setel.Carbohydrates;
                    Bellabel5.Text = setel.Protein;
                    Jirlabel5.Text = setel.Fats;
                    Callabel5.Text = setel.Callories;

                }
            }
        }
        private void MultiBox6_TextChanged(object sender, EventArgs e)
        {
            Energoelements setel = (Energoelements)(EatBox6.SelectedItem);
            if (EatBox6.Text == "")
            {
                return;
            }
            try
            {
                if (Convert.ToDecimal(MultiBox6.Text) >= 0)
                {
                    Ugllabel6.Text = (Convert.ToDecimal(setel.Carbohydrates) * Convert.ToDecimal(MultiBox6.Text)).ToString();
                    Bellabel6.Text = (Convert.ToDecimal(setel.Protein) * Convert.ToDecimal(MultiBox6.Text)).ToString();
                    Jirlabel6.Text = (Convert.ToDecimal(setel.Fats) * Convert.ToDecimal(MultiBox6.Text)).ToString();
                    Callabel6.Text = (Convert.ToDecimal(setel.Callories) * Convert.ToDecimal(MultiBox6.Text)).ToString();
                }
            }
            catch (Exception)
            {
                if (MultiBox6.Text == "")
                {
                    Ugllabel6.Text = setel.Carbohydrates;
                    Bellabel6.Text = setel.Protein;
                    Jirlabel6.Text = setel.Fats;
                    Callabel6.Text = setel.Callories;

                }
            }
        }
        #endregion

        #region ChangeValue Logic
        private void Ugllabel1_TextChanged(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();

        }
        private void Ugllabel2_TextChanged(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();

        }
        private void Ugllabel3_TextChanged(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();

        }
        private void Ugllabel4_TextChanged(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();

        }
        private void Ugllabel5_TextChanged(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();

        }
        private void Ugllabel6_TextChanged(object sender, EventArgs e)
        {
            AllUgllabel.Text = (Convert.ToDecimal(Ugllabel1.Text) + Convert.ToDecimal(Ugllabel2.Text) + Convert.ToDecimal(Ugllabel3.Text) + Convert.ToDecimal(Ugllabel4.Text) + Convert.ToDecimal(Ugllabel5.Text) + Convert.ToDecimal(Ugllabel6.Text)).ToString();

        }
        private void Bellabel1_TextChanged(object sender, EventArgs e)
        {
            AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();

        }
        private void Bellabel2_TextChanged(object sender, EventArgs e)
        {
            AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();

        }
        private void Bellabel3_TextChanged(object sender, EventArgs e)
        {
            AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();

        }
        private void Bellabel4_TextChanged(object sender, EventArgs e)
        {
            AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();

        }
        private void Bellabel5_TextChanged(object sender, EventArgs e)
        {
            AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();

        }
        private void Bellabel6_TextChanged(object sender, EventArgs e)
        {
            AllBellabel.Text = (Convert.ToDecimal(Bellabel1.Text) + Convert.ToDecimal(Bellabel2.Text) + Convert.ToDecimal(Bellabel3.Text) + Convert.ToDecimal(Bellabel4.Text) + Convert.ToDecimal(Bellabel5.Text) + Convert.ToDecimal(Bellabel6.Text)).ToString();

        }
        private void Jirlabel1_TextChanged(object sender, EventArgs e)
        {
            AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();

        }
        private void Jirlabel2_TextChanged(object sender, EventArgs e)
        {
            AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();

        }
        private void Jirlabel3_TextChanged(object sender, EventArgs e)
        {
            AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();

        }
        private void Jirlabel4_TextChanged(object sender, EventArgs e)
        {
            AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();

        }
        private void Jirlabel5_TextChanged(object sender, EventArgs e)
        {
            AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();

        }
        private void Jirlabel6_TextChanged(object sender, EventArgs e)
        {
            AllJirlabel.Text = (Convert.ToDecimal(Jirlabel1.Text) + Convert.ToDecimal(Jirlabel2.Text) + Convert.ToDecimal(Jirlabel3.Text) + Convert.ToDecimal(Jirlabel4.Text) + Convert.ToDecimal(Jirlabel5.Text) + Convert.ToDecimal(Jirlabel6.Text)).ToString();

        }
        private void Callabel1_TextChanged(object sender, EventArgs e)
        {
            AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();

        }
        private void Callabel2_TextChanged(object sender, EventArgs e)
        {
            AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();

        }
        private void Callabel3_TextChanged(object sender, EventArgs e)
        {
            AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();

        }
        private void Callabel4_TextChanged(object sender, EventArgs e)
        {
            AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();

        }
        private void Callabel5_TextChanged(object sender, EventArgs e)
        {
            AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();

        }
        private void Callabel6_TextChanged(object sender, EventArgs e)
        {
            AllCallabel.Text = (Convert.ToDecimal(Callabel1.Text) + Convert.ToDecimal(Callabel2.Text) + Convert.ToDecimal(Callabel3.Text) + Convert.ToDecimal(Callabel4.Text) + Convert.ToDecimal(Callabel5.Text) + Convert.ToDecimal(Callabel6.Text)).ToString();

        }
       
    }
    #endregion
}
