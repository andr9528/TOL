using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Library;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Gods.xaml
    /// </summary>
    public partial class Gods : Window
    {
        Storage Store = new Storage();
        List<Library.Gods> divines = new List<Library.Gods>();

        public Gods()
        {
            InitializeComponent();

            divines.AddRange(Storage.GreekGods);
            // divines.AddRange(Storage.EgyptianGods);
            // divines.AddRange(Storage.NordicGods);
            // divines.AddRange(Storage.AtlanticTitans);
        }

        private void CloseDivine_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DropDownDivine_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> divinesS = new List<string>();

            divinesS.AddRange(Storage.GodGreekString);
            divinesS.AddRange(Storage.GodEgyptianString);
            divinesS.AddRange(Storage.GodNordicString);
            divinesS.AddRange(Storage.GodAtlanticString);

            var DropDownDivine = sender as ComboBox;

            DropDownDivine.ItemsSource = divinesS;

            DropDownDivine.SelectedIndex = 0;
        }

        private void DropDownDivine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int weightSum = 0;
            int xpSum = 0;

            if (DropDownDivine.SelectedIndex > 11)
            {
                ErrorBox.Text = "Error 1";
                SumWeightValue.Text = "";
                SumXpValue.Text = "";

                ArcheryWeightValue.Text = "";
                OneHandedWeightValue.Text = "";
                TwoHandedWeightValue.Text = "";
                LightArmorWeightValue.Text = "";
                HeavyArmorWeightValue.Text = "";
                StealthWeightValue.Text = "";
                AgilityWeightValue.Text = "";
                SmithingWeightValue.Text = "";
                EnchantingWeightValue.Text = "";
                AlchemyWeightValue.Text = "";
                BlockingWeightValue.Text = "";
                WildMagicWeightValue.Text = "";
                InfernoMagicWeightValue.Text = "";
                BlizzMagicWeightValue.Text = "";
                SkyMagicWeightValue.Text = "";
                PureMagicWeightValue.Text = "";

                ArcheryXpValue.Text = "";
                OneHandedXpValue.Text = "";
                TwoHandedXpValue.Text = "";
                LightArmorXpValue.Text = "";
                HeavyArmorXpValue.Text = "";
                StealthXpValue.Text = "";
                AgilityXpValue.Text = "";
                SmithingXpValue.Text = "";
                EnchantingXpValue.Text = "";
                AlchemyXpValue.Text = "";
                BlockingXpValue.Text = "";
                WildMagicXpValue.Text = "";
                InfernoMagicXpValue.Text = "";
                BlizzMagicXpValue.Text = "";
                SkyMagicXpValue.Text = "";
                PureMagicXpValue.Text = "";

            }
            else
            {
                ErrorBox.Text = "";

                ArcheryWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[0];
                OneHandedWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[1];
                TwoHandedWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[2];
                LightArmorWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[3];
                HeavyArmorWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[4];
                StealthWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[5];
                AgilityWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[6];
                SmithingWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[7];
                EnchantingWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[8];
                AlchemyWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[9];
                BlockingWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[10];
                WildMagicWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[11];
                InfernoMagicWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[12];
                BlizzMagicWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[13];
                SkyMagicWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[14];
                PureMagicWeightValue.Text = divines[DropDownDivine.SelectedIndex].Favoring.Split(',')[15];

                foreach (string favor in divines[DropDownDivine.SelectedIndex].Favoring.Split(','))
                {
                    favor.TrimStart(' ');
                    weightSum += int.Parse(favor);
                }

                SumWeightValue.Text = "" + weightSum;

                ArcheryXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[0]; 
                OneHandedXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[1];
                TwoHandedXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[2];
                LightArmorXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[3];
                HeavyArmorXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[4];
                StealthXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[5];
                AgilityXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[6];
                SmithingXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[7];
                EnchantingXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[8];
                AlchemyXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[9];
                BlockingXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[10];
                WildMagicXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[11];
                InfernoMagicXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[12];
                BlizzMagicXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[13];
                SkyMagicXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[14];
                PureMagicXpValue.Text = "" + divines[DropDownDivine.SelectedIndex].XpModifier[15];

                foreach (int xp in divines[DropDownDivine.SelectedIndex].XpModifier)
                {
                    xpSum += xp;
                }

                SumXpValue.Text = "" + xpSum;

                //DropDownXpCheck.ItemsSource = divines[DropDownDivine.SelectedIndex].XpModifier;

                //DropDownXpCheck.SelectedIndex = 0;
            }
        }

        //private void DropDownXpCheck_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var DropDownXpCheck = sender as ComboBox;

        //    DropDownXpCheck.ItemsSource = divines[DropDownDivine.SelectedIndex].XpModifier;

        //    DropDownXpCheck.SelectedIndex = 0;
        //}
    }
}
