using Library;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for Characters.xaml
    /// </summary>
    public partial class Characters : Window
    {
        List<string> CurrentCharacters = new List<string>() {"None" };
        public Characters()
        {
            InitializeComponent();

            foreach (Player player in Repo.GetCharacters())
            {
                CurrentCharacters.Add(player.ToStringPlayer());
            }

            CharacterSelector.ItemsSource = CurrentCharacters;
            CharacterSelector.SelectedIndex = 0;
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CharacterSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CharacterSelector.SelectedIndex != 0)
            {
                Player player = Repo.GetCharacters()[CharacterSelector.SelectedIndex - 1];

                Health.Text = player.CurrentHealth + "/" + player.MaxHealth;
                Mana.Text = player.CurrentMana + "/" + player.MaxMana;
                HealthRegen.Text = player.HealthRegeneration.ToString();
                ManaRegen.Text = player.ManaRegeneration.ToString();
                DodgeChance.Text = player.DodgeChance.ToString();
                BlockChance.Text = player.BlockChance.ToString();
                CriticalChance.Text = player.CriticalChance.ToString();
                CriticalMultiplier.Text = player.CriticalDamageMultiplier.ToString();
                MinDamage.Text = player.MinimumDamage.ToString();
                MaxDamage.Text = player.MaximumDamage.ToString();
                Protection.Text = player.Protection.ToString();
                AttackSpeed.Text = player.AttackSpeed.ToString();
                Level.Text = player.Level.ToString();

                if (player.Amulet != null)
                {
                    EquipAmulet.Content = "Amulet: " + player.Amulet.ToStringEN();
                }
                else
                {
                    EquipAmulet.Content = "Amulet: Empty";
                }
                if (player.Belt != null)
                {
                    EquipBelt.Content = "Belt: " + player.Belt.ToStringEN();
                }
                else
                {
                    EquipBelt.Content = "Belt: Empty";
                }
                if (player.Boots != null)
                {
                    EquipBoots.Content = "Boots: " + player.Boots.ToStringEN();
                }
                else
                {
                    EquipBoots.Content = "Boots: Empty";
                }
                if (player.Braces != null)
                {
                    EquipBraces.Content = "Braces: " + player.Braces.ToStringEN();
                }
                else
                {
                    EquipBraces.Content = "Braces: Empty";
                }
                if (player.Chestplate != null)
                {
                    EquipChestplate.Content = "Chestplate: " + player.Chestplate.ToStringEN();
                }
                else
                {
                    EquipChestplate.Content = "Chestplate: Empty";
                }
                if (player.Gloves != null)
                {
                    EquipGloves.Content = "Gloves: " + player.Gloves.ToStringEN();
                }
                else
                {
                    EquipGloves.Content = "Gloves: Empty";
                }
                if (player.Head != null)
                {
                    EquipHead.Content = "Head: " + player.Head.ToStringEN();
                }
                else
                {
                    EquipHead.Content = "Head: Empty";
                }
                if (player.LeftRing != null)
                {
                    EquipLeftRing.Content = "Left Ring: " + player.LeftRing.ToStringEN();
                }
                else
                {
                    EquipLeftRing.Content = "Left Ring: Empty";
                }
                if (player.Leggings != null)
                {
                    EquipLeggings.Content = "Leggings: " + player.Leggings.ToStringEN();
                }
                else
                {
                    EquipLeggings.Content = "Leggings: Empty";
                }
                if (player.MainHand != null)
                {
                    EquipMainHand.Content = "Main Hand: " + player.MainHand.ToStringEN();
                }
                else
                {
                    EquipMainHand.Content = "Main Hand: Empty";
                }
                if (player.OffHand != null)
                {
                    EquipOffHand.Content = "Off Hand: " + player.OffHand.ToStringEN();
                }
                else
                {
                    EquipOffHand.Content = "Off Hand: Empty";
                }
                if (player.Ranged != null)
                {
                    EquipRanged.Content = "Ranged: " + player.Ranged.ToStringEN();
                }
                else
                {
                    EquipRanged.Content = "Ranged: Empty";
                }
                if (player.RightRing != null)
                {
                    EquipRightRing.Content = "Right Ring: " + player.RightRing.ToStringEN();
                }
                else
                {
                    EquipRightRing.Content = "Right Ring: Empty";
                }
                if (player.Shoulder != null)
                {
                    EquipShoulders.Content = "Shoulders: " + player.Shoulder.ToStringEN();
                }
                else
                {
                    EquipShoulders.Content = "Shoulders: Empty";
                }

                SkillGrid.ItemsSource = player.GetSkills();
            }
            else
            {
                Health.Text = "";
                Mana.Text = "";
                HealthRegen.Text = "";
                ManaRegen.Text = "";
                DodgeChance.Text = "";
                BlockChance.Text = "";
                CriticalChance.Text = "";
                CriticalMultiplier.Text = "";
                MinDamage.Text = "";
                MaxDamage.Text = "";
                Protection.Text = "";
                AttackSpeed.Text = "";
                Level.Text = "";

                EquipAmulet.Content = "Amulet: Empty";
                EquipBelt.Content = "Belt: Empty";
                EquipBoots.Content = "Boots: Empty";
                EquipBraces.Content = "Braces: Empty";
                EquipChestplate.Content = "Chestplate: Empty";
                EquipGloves.Content = "Gloves: Empty";
                EquipHead.Content = "Head: Empty";
                EquipLeftRing.Content = "Left Ring: Empty";
                EquipLeggings.Content = "Leggings: Empty";
                EquipMainHand.Content = "Main Hand: Empty";
                EquipOffHand.Content = "Off Hand: Empty";
                EquipRanged.Content = "Ranged: Empty";
                EquipRightRing.Content = "Right Ring: Empty";
                EquipShoulders.Content = "Shoulders: Empty";

                SkillGrid.ItemsSource = null;
            }
        }

        private void EquipRanged_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipHead_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipAmulet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipShoulders_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipChestplate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipGloves_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipLeggings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipBelt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipBoots_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipLeftRing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipRightRing_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipMainHand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipOffHand_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EquipBraces_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
