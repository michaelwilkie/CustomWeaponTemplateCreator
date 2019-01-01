using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace custom_weapon_template
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            weaptypeBox.Items.Add("sniper");
            weaptypeBox.Items.Add("rifle");
            weaptypeBox.Items.Add("shotgun");
            weaptypeBox.Items.Add("pistol");
            weaptypeBox.Items.Add("melee");
            ammotypeBox.Items.Add("9mm");
            ammotypeBox.Items.Add("357");
            ammotypeBox.Items.Add("buckshot");
            ammotypeBox.Items.Add("556");
            ammotypeBox.Items.Add("762");
            hudBox.Items.Add("Crowbar");
            hudBox.Items.Add("Wrench");
            hudBox.Items.Add("9mmhandgun");
            hudBox.Items.Add("Revolver");
            hudBox.Items.Add("MP5");
            hudBox.Items.Add("Spas");
            hudBox.Items.Add("M16");
            hudBox.Items.Add("M249");
            hudBox.Items.Add("Uzi");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modeladd_Click(object sender, EventArgs e)
        {
            string model = modeltextBox.Text;
            // Check if user specified root folder
            if (roottextBox.Text.Length < 1)
            {
                MessageBox.Show("Please specify the root folder");
                return;
            }
            // Check if user entered file manually via text box
            if (modeltextBox.Text.Length > 0)
            {
                // Check for duplicates
                if (CollectionContains(model, modellistBox.Items))
                    return;
            }
            else
            {

                string filename;
                // If the user clicked "OK" on the File Browser
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    int substr = filename.IndexOf(roottextBox.Text);
                    // Does filename contain root folder name?
                    if (substr == -1)
                    {
                        MessageBox.Show("Root folder not found");
                        return;
                    }
                    // Path gets file path with respect to the root folder           
                    model = filename.Substring(substr + roottextBox.Text.Length + 1);

                    // Check for duplicates
                    if (CollectionContains(model, modellistBox.Items))
                        return;
                }
                else
                    return;
            }
            // Add to the list
            modellistBox.Items.Add(model);
            vmodelBox.Items.Add(model);
            pmodelBox.Items.Add(model);
            wmodelBox.Items.Add(model);
            return;
        }
        private bool CollectionContains(string model, ListBox.ObjectCollection items)
        {
            foreach (var item in items)
            {
                if (item.ToString() == model)
                {
                    MessageBox.Show(String.Format("{0} is already in the list", model));
                    return true;
                }
            }
            return false;
        }
        private bool CollectionContains(string model, ComboBox.ObjectCollection items)
        {
            foreach (var item in items)
            {
                if (item.ToString() == model)
                {
                    MessageBox.Show(String.Format("{0} is already in the list", model));
                    return true;
                }
            }
            return false;
        }

        private void soundadd_Click(object sender, EventArgs e)
        {
            string sound = soundtextBox.Text;
            // Check if user specified root folder
            if (roottextBox.Text.Length < 1)
            {
                MessageBox.Show("Please specify the root folder");
                return;
            }
            // Check if user entered file manually via text box
            if (soundtextBox.Text.Length > 0)
            {
                // Check for duplicates
                if (CollectionContains(sound, soundlistBox.Items))
                    return;
            }
            else
            {
                string filename;
                // If the user clicked "OK" on the File Browser
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    filename = openFileDialog1.FileName;
                    int substr = filename.IndexOf(roottextBox.Text);

                    // Does filename contain root folder name?
                    if (substr == -1)
                    {
                        MessageBox.Show("Root folder not found");
                        return;
                    }
                    // Path gets file path with respect to the root folder
                    sound = filename.Substring(substr + roottextBox.Text.Length + 1);
                    substr = sound.IndexOf("sound/");
                    if (substr == -1)
                        sound = sound.Substring(6); // "sound/" is 6 characters long, so skip this
                    // Check for duplicates
                    if (CollectionContains(sound, soundlistBox.Items))
                        return;
                }
                else
                    return;
            }
            // Add to the lists
            soundlistBox.Items.Add(sound);
            firesndBox.Items.Add(sound);
            reloadsndBox.Items.Add(sound);
            meleemisssndBox.Items.Add(sound);
            return;
        }

        private void modelremove_Click(object sender, EventArgs e)
        {
            if (modellistBox.SelectedIndex < 0)
                return;
            string obj = modellistBox.SelectedItem.ToString();
            foreach(string s in modellistBox.Items)
            {
                if (obj == s)
                {
                    modellistBox.Items.Remove(s);
                    break;
                }
            }
            foreach (string s in vmodelBox.Items)
            {
                if (obj == s)
                {
                    vmodelBox.Items.Remove(s);
                    break;
                }
            }
            foreach (string s in pmodelBox.Items)
            {
                if (obj == s)
                {
                    pmodelBox.Items.Remove(s);
                    break;
                }
            }
            foreach (string s in wmodelBox.Items)
            {
                if (obj == s)
                {
                    wmodelBox.Items.Remove(s);
                    break;
                }
            }
        }

        private void soundremove_Click(object sender, EventArgs e)
        {
            if (soundlistBox.SelectedIndex < 0)
                return;
            string obj = soundlistBox.SelectedItem.ToString();
            foreach (string s in soundlistBox.Items)
            {
                if (obj == s)
                {
                    soundlistBox.Items.Remove(s);
                    break;
                }
            }
            foreach (string s in firesndBox.Items)
            {
                if (obj == s)
                {
                    firesndBox.Items.Remove(s);
                    break;
                }
            }
            foreach (string s in reloadsndBox.Items)
            {
                if (obj == s)
                {
                    reloadsndBox.Items.Remove(s);
                    break;
                }
            }
            foreach (string s in meleemisssndBox.Items)
            {
                if (obj == s)
                {
                    meleemisssndBox.Items.Remove(s);
                    break;
                }
            }
            return;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void rootButton_Click(object sender, EventArgs e)
        {
            // If the user clicked "OK" on the File Browser
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)           
                roottextBox.Text = folderBrowserDialog1.SelectedPath;
            return;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a list of empty fields
            List<string> emptylist = new List<string>();

            // Check if any text boxes have invalid inputs
            if(string.IsNullOrWhiteSpace(roottextBox.Text))          emptylist.Add("Root field is empty or invalid"           );
            if (weaptypeBox.SelectedItem  == null)                   emptylist.Add("Select weapon type"                       );
            if (ammotypeBox.SelectedItem  == null)                   emptylist.Add("Select ammo type"                         );
            if (hudBox.SelectedItem       == null)                   emptylist.Add("Select HUD icon"                          );
            if (wmodelBox.SelectedItem    == null)                   emptylist.Add("Select w_ model"                          );
            if (vmodelBox.SelectedItem    == null)                   emptylist.Add("Select v_ model"                          );
            if (pmodelBox.SelectedItem    == null)                   emptylist.Add("Select p_ model"                          );
            if (firesndBox.SelectedItem   == null)                   emptylist.Add("Select fire sound"                        );
            if (reloadsndBox.SelectedItem == null)                   emptylist.Add("Select reload sound"                      );
            if (string.IsNullOrWhiteSpace(dmgtextBox.Text         )) emptylist.Add("Damage field is empty or invalid"         );
            if (string.IsNullOrWhiteSpace(cliptextBox.Text        )) emptylist.Add("Clip size field is empty or invalid"      );
            if (string.IsNullOrWhiteSpace(dmgtextBox.Text         )) emptylist.Add("Damage field is empty or invalid"         );
            if (string.IsNullOrWhiteSpace(ammotextBox.Text        )) emptylist.Add("Ammo field is empty or invalid"           );
            if (string.IsNullOrWhiteSpace(fireratetextBox.Text    )) emptylist.Add("Fire rate field is empty or invalid"      );
            if (string.IsNullOrWhiteSpace(reloadtextBox.Text      )) emptylist.Add("Reload speed field is empty or invalid"   );
            if (string.IsNullOrWhiteSpace(fire_anim_textBox.Text  )) emptylist.Add("Fire anim. field is empty or invalid"     );
            if (string.IsNullOrWhiteSpace(reload_anim_textBox.Text)) emptylist.Add("Reload anim. field is empty or invalid"   );
            if (string.IsNullOrWhiteSpace(idle_anim_textBox.Text  )) emptylist.Add("Idle anim. field is empty or invalid"     );
            if (string.IsNullOrWhiteSpace(weapslottextBox.Text    )) emptylist.Add("Weapon slot field is empty or invalid"    );
            if (string.IsNullOrWhiteSpace(positiontextBox.Text    )) emptylist.Add("Weapon position field is empty or invalid");

            if (emptylist.Count != 0)
            {
                string result = "";
                foreach (string str in emptylist)
                    result = str + result + "\r\n";

                MessageBox.Show("Error:\r\n"+result);
                return;
            }

            // Retrieve data from Windows Form
            string header      = "//\r\n//Generated by Custom Weapon Creator\r\n//\r\n";
            string root        = roottextBox.Text;
            string weaponname  = weaponnameTextbox.Text;
            string weapontype  = weaptypeBox.Text;
            string ammotype    = ammotextBox.Text;
            int    dmg         = System.Convert.ToInt32(dmgtextBox.Text);
            int    clip        = System.Convert.ToInt32(cliptextBox.Text);
            int    ammo        = System.Convert.ToInt32(ammotextBox.Text);
            int fireindex      = System.Convert.ToInt32(fire_anim_numtextBox.Text);
            int reloadindex    = System.Convert.ToInt32(reload_anim_numtextBox.Text);
            int missindex = 0;
            if (weapontype == "melee")
                missindex = System.Convert.ToInt32(miss_anim_numtextBox.Text);
            int drawindex      = System.Convert.ToInt32(draw_anim_numtextBox.Text);
            int idleindex      = System.Convert.ToInt32(idle_anim_numtextBox.Text);
            double nextattack  = System.Convert.ToDouble(fireratetextBox.Text);
            double reloadspeed = System.Convert.ToDouble(reloadtextBox.Text);
            string fireanim    = fire_anim_textBox.Text;
            string reloadanim  = reload_anim_textBox.Text;
            string idleanim    = idle_anim_textBox.Text;
            string drawanim    = drawanim_textBox.Text;
            string missanim    = melee_miss_textBox.Text;
            int slot           = System.Convert.ToInt32(weapslottextBox.Text);
            string firesound   = firesndBox.Text;
            string reloadsound = reloadsndBox.Text;
            string misssound   = meleemisssndBox.Text;

            firesound = firesound.Replace("\\", "/");
            reloadsound = reloadsound.Replace("\\", "/");
            misssound = misssound.Replace("\\", "/");

            string vmodel = vmodelBox.SelectedItem.ToString();
            string wmodel = wmodelBox.SelectedItem.ToString();
            string pmodel = pmodelBox.SelectedItem.ToString();

            vmodel = vmodel.Replace("\\", "/");
            wmodel = wmodel.Replace("\\", "/");
            pmodel = pmodel.Replace("\\", "/");

            string shortname;

            // Create a nick name for weapon
            int index = weaponname.IndexOf("weapon_");
            if (index == -1)
                shortname = weaponname;
            else
                shortname = weaponname.Substring(7);   // weapon_ is 7 characters long

            // Short cut names for global variables
            string next_attack = "NEXT_ATTACK";
            string max_clip = shortname + "_MAX_CLIP";
            string max_ammo = shortname + "_MAX_AMMO";
            string max_dmg = shortname + "_MAX_DMG";
            string default_give = shortname + "_DEFAULT_GIVE";

            // Create new file at root/scripts/maps
            System.IO.StreamWriter file = new System.IO.StreamWriter(root + String.Format(@"/scripts/maps/{0}.as", weaponname));

            // Write the header
            file.Write(header);

            // List animations
            file.Write("\r\n");
            file.Write(String.Format("enum {0}Animation\r\n", shortname));
            file.Write("{\r\n");
            if (weapontype != "melee")
                file.Write(String.Format("\t{0} = {1},\r\n\t{2} = {3},\r\n\t{4} = {5},\r\n\t{6} = {7}\r\n",
                    idleanim, idleindex,
                    reloadanim, reloadindex,
                    fireanim, fireindex,
                    drawanim, drawindex));
            else
                file.Write(String.Format("\t{0} = {1},\r\n\t{2} = {3},\r\n\t{4} = {5},\r\n{6} = {7}\r\n",
                    idleanim, idleindex,
                    missanim, missindex,
                    fireanim, fireindex,
                    drawanim, drawindex));

            file.Write("};\r\n\r\n");            

            // Class declaration
            file.Write(String.Format("class {0} : ScriptBasePlayerWeaponEntity\r\n", weaponname));
            file.Write("{\r\n");

            file.Write("\tprivate CBasePlayer@ m_pPlayer = null;\r\n");

            // Globals
            if (weapontype != "melee")
            {
                file.Write(String.Format("\tint {0} = {1};\r\n", max_clip, clip));
                file.Write(String.Format("\tint {0} = {1};\r\n", max_ammo, ammo));
                file.Write(String.Format("\tint {0} = {1};\r\n", max_dmg, dmg));
                file.Write(String.Format("\tint {0} = {1};\r\n", default_give, clip));

            }
            if (weapontype == "sniper")
            {
                file.Write("\tint g_iCurrentMode;\r\n");
                file.Write("\tstring ZoomSound = \"weapons/sniper_zoom.wav\";\r\n");
                file.Write("\tint NOSCOPE = 0;\r\n");
                file.Write("\tint SCOPE = 1;\r\n");
            }
            if (weapontype == "shotgun")
            {
                file.Write("\tVector VECTOR_CONE_DM_SHOTGUN( 0.08716, 0.04362, 0.00  );  // 10 degrees by 5 degrees\r\n");
                file.Write("\tVector VECTOR_CONE_DM_DOUBLESHOTGUN( 0.17365, 0.04362, 0.00 );  // 20 degrees by 5 degrees\r\n");
                file.Write("\tfloat m_flNextReload;\r\n");
                file.Write("\tfloat m_flPumpTime;\r\n");
                file.Write("\tbool m_fPlayPumpSound;\r\n");
                file.Write("\tbool m_fShotgunReload;\r\n");
            }
            if (semiauto_checkBox.Checked)
                file.Write("\tint m_iShotsFired;\r\n");

            file.Write(String.Format("\tfloat {0} = {1:F2};\r\n", next_attack, nextattack));

            if (weapontype != "melee")
                file.Write("\tint m_iShell;\r\n");
            else
            {
                file.Write("\tint m_iSwing;\r\n");
                file.Write("\tTraceResult m_trHit;\r\n");
            }
            file.Write("\r\n");
            // Spawn() function
            file.Write("\tvoid Spawn()\r\n");
            file.Write("\t{\r\n");
            file.Write("\t\tPrecache();\r\n");
            file.Write(String.Format("\t\tg_EntityFuncs.SetModel(self, \"{0}\");\r\n", wmodel));

            if (weapontype != "melee")
                file.Write(String.Format("\t\tself.m_iDefaultAmmo = {0};\r\n", default_give));
            else
            {
                file.Write("\t\tself.m_iClip = -1;\r\n");
                file.Write("\t\tself.m_flCustomDmg = self.pev.dmg;\r\n");
            }
            if (weapontype == "sniper")
            {
                file.Write("\t\tg_iCurrentMode = NOSCOPE;\r\n");
            }
            if (semiauto_checkBox.Checked)
                file.Write("\t\tm_iShotsFired = 0;\r\n");
            file.Write("\t\tself.FallInit();\r\n");
            file.Write("\t}\r\n");
            // End Spawn() function

            // Precache() function
            file.Write("\tvoid Precache()\r\n");
            file.Write("\t{\r\n");
            file.Write("\t\tself.PrecacheCustomModels();\r\n");
            foreach(string s in modellistBox.Items)
            {
                file.Write(String.Format("\t\tg_Game.PrecacheModel( \"{0}\" );\r\n", s.Replace("\\","/")));
            }
            foreach (string s in soundlistBox.Items)
            {
                file.Write(String.Format("\t\tg_SoundSystem.PrecacheSound( \"{0}\" );\r\n", s.Replace("\\", "/")));
            }
            file.Write("\t\tg_SoundSystem.PrecacheSound( \"hl/weapons/357_cock1.wav\" );\r\n");   // default empty sound
            file.Write("\t\tg_SoundSystem.PrecacheSound( ZoomSound );\r\n"); 
            file.Write("\t}\r\n");
            // End Precache() function

            // GetItemInfo(...) function
            file.Write("\tbool GetItemInfo( ItemInfo& out info )\r\n");
            file.Write("\t{\r\n");
            if (weapontype == "melee")
            {
                file.Write("\t\tinfo.iMaxAmmo1 = -1;\r\n");
                file.Write("\t\tinfo.iMaxAmmo2 = -1;\r\n");
                file.Write("\t\tinfo.iMaxClip = WEAPON_NOCLIP;\r\n");
                file.Write(String.Format("\t\tinfo.iSlot = {0};\r\n", slot));
                file.Write(String.Format("\t\tinfo.iPosition = {0};\r\n", slot));
                file.Write("\t\tinfo.iWeight = 10;\r\n");
                file.Write("\t\treturn true;\r\n");
            }
            else
            {
                file.Write(String.Format("\t\tinfo.iMaxAmmo1 = {0};\r\n", max_ammo));
                file.Write("\t\tinfo.iMaxAmmo2 = -1;\r\n");
                file.Write(String.Format("\t\tinfo.iMaxClip = {0};\r\n", max_clip));
                file.Write(String.Format("\t\tinfo.iSlot = {0};\r\n", slot));
                file.Write(String.Format("\t\tinfo.iPosition = {0};\r\n", slot));
                file.Write("\t\tinfo.iWeight = 10;\r\n");
                file.Write("\t\treturn true;\r\n");
            }
            file.Write("\t}\r\n");
            // End GetItemInfo(...) function

            // AddToPlayer( CBasePlayer@ pPlayer ) function
            file.Write("\tbool AddToPlayer(CBasePlayer@ pPlayer)\r\n");
            file.Write("\t{\r\n");
            file.Write("\t\tif ( !BaseClass.AddToPlayer( pPlayer ) )\r\n");
            file.Write("\t\t\treturn false;\r\n\r\n");
            file.Write("\t\t@m_pPlayer = pPlayer;\r\n");
            file.Write("\t\tNetworkMessage message( MSG_ONE, NetworkMessages::WeapPickup, pPlayer.edict() );\r\n");
            file.Write("\t\tmessage.WriteLong( self.m_iId );\r\n");
            file.Write("\t\tmessage.End();\r\n");
            file.Write("\t\treturn true;\r\n");
            file.Write("\t}\r\n");
            // End AddToPlayer(...) function
            if (weapontype != "melee")
            {
                // PlayEmptySound() function
                file.Write("\tbool PlayEmptySound()\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tif( self.m_bPlayEmptySound )\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tself.m_bPlayEmptySound = false;\r\n");
                file.Write("\t\t\tg_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_WEAPON, \"hl/weapons/357_cock1.wav\", 0.8, ATTN_NORM, 0, PITCH_NORM );\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t\treturn false;\r\n");
                file.Write("\t}\r\n");
                // End PlayEmptySound() function
            }
            // Depoy() function
            string holdtype;
            if      (weapontype == "pistol" )  holdtype = "onehanded";
            else if (weapontype == "shotgun")  holdtype = "shotgun"  ;
            else if (weapontype == "rifle"  )  holdtype = "mp5"      ;
            else if (weapontype == "sniper" )  holdtype = "sniper"   ;
            else                               holdtype = "crowbar"  ;
               
            file.Write("\tbool Deploy()\r\n");
            file.Write("\t{\r\n");
            if (weapontype == "sniper")
            {
                file.Write("\t\tg_iCurrentMode = NOSCOPE;\r\n");
                file.Write("\t\tToggleZoom( 0 );\r\n");
            }
            file.Write(String.Format("\t\treturn self.DefaultDeploy( self.GetV_Model( \"{0}\" ), self.GetP_Model( \"{1}\" ), {2}, \"{3}\");\r\n", vmodel, pmodel, drawanim, holdtype));
            file.Write("\t}\r\n");
            // End Deploy() function

            // Holster() function
            file.Write("\tvoid Holster( int skiplocal = 0 )\r\n");
            file.Write("\t{\r\n");
            file.Write("\t\tself.m_fInReload = false;\r\n\r\n");
            file.Write("\t\tm_pPlayer.m_flNextAttack = g_WeaponFuncs.WeaponTimeBase() + 0.5;\r\n\r\n");
            file.Write("\t\tBaseClass.Holster( skipLocal );\r\n");
            file.Write("\t}\r\n");
            // End Holster() function

            if (weapontype == "shotgun") 
            {
                // CreatePelletDecals(...) function
                file.Write("\tvoid CreatePelletDecals( const Vector& in vecSrc, const Vector& in vecAiming, const Vector& in vecSpread, const uint uiPelletCount )\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tTraceResult tr;\r\n");
                file.Write("\t\tfloat x, y;\r\n\r\n");
                file.Write("\t\tfor( uint uiPellet = 0; uiPellet < uiPelletCount; ++uiPellet )\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tg_Utility.GetCircularGaussianSpread( x, y );\r\n");
                file.Write("\t\tVector vecDir = vecAiming\r\n");
                file.Write("\t\t\t\t\t\t+ x * VECTOR_CONE_6DEGREES.x * g_Engine.v_right \r\n");
                file.Write("\t\t\t\t\t\t+ y * VECTOR_CONE_6DEGREES.y * g_Engine.v_up;\r\n\r\n");
                file.Write("\t\t\tVector vecEnd	= vecSrc + vecDir * 4096;\r\n");
                file.Write("\t\t\tg_Utility.TraceLine( vecSrc, vecEnd, dont_ignore_monsters, m_pPlayer.edict(), tr );\r\n");
                file.Write("\t\t\tif( tr.flFraction < 1.0 )\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write("\t\t\t\tif( tr.pHit !is null )\r\n");
                file.Write("\t\t\t\t{\r\n");
                file.Write("\t\t\t\t\tCBaseEntity@ pHit = g_EntityFuncs.Instance( tr.pHit );\r\n");
                file.Write("\t\t\t\t\tif( pHit is null || pHit.IsBSPModel() )\r\n");
                file.Write("\t\t\t\t\t\tg_WeaponFuncs.DecalGunshot( tr, BULLET_PLAYER_BUCKSHOT );\r\n");
                file.Write("\t\t\t\t}\r\n");
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t}\r\n");
                // End CreatePelletDecals(...) function
            }

            // PrimaryAttack() function
            file.Write("\tvoid PrimaryAttack()\r\n");
            file.Write("\t{\r\n");
            if (weapontype != "melee")
            {
                file.Write("\t\t//dont fire under water\r\n");
                file.Write("\t\tif( m_pPlayer.pev.waterlevel == WATERLEVEL_HEAD )\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tself.PlayEmptySound();\r\n");
                file.Write(String.Format("\t\t\tself.m_flNextPrimaryAttack = g_Engine.time + {0};\r\n", next_attack));
                file.Write("\t\t\treturn;\r\n");
                file.Write("\t\t}\r\n\r\n");
                file.Write("\t\tif (self.m_iClip <= 0)\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tself.PlayEmptySound();\r\n");
                file.Write(String.Format("\t\t\tself.m_flNextPrimaryAttack = g_Engine.time + {0};\r\n", next_attack));
                file.Write("\t\t\treturn;\r\n");
                file.Write("\t\t}\r\n\r\n");
                if (semiauto_checkBox.Checked)
                {
                    file.Write("\t\tm_iShotsFired++;\r\n");
                    file.Write("\t\tif (m_iShotsFired > 1)\r\n");
                    file.Write("\t\t{\r\n");
                    file.Write("\t\t\treturn;\r\n");
                    file.Write("\t\t}\r\n");
                }
                if (weapontype == "shotgun")
                {
                    file.Write("\t\tif( self.m_iClip != 0 )\r\n");
                    file.Write("\t\t\tm_flPumpTime = g_Engine.time + 0.5;\r\n");                    
                }
                file.Write("\t\tm_pPlayer.m_iWeaponVolume = NORMAL_GUN_VOLUME;\r\n");
                file.Write("\t\tm_pPlayer.m_iWeaponFlash = NORMAL_GUN_FLASH;\r\n\r\n");

                file.Write("\t\t--self.m_iClip;\r\n\r\n");
                file.Write(String.Format("\t\tself.SendWeaponAnim( {0}, 0, 0 );\r\n", fireanim));
                file.Write(String.Format("\t\tg_SoundSystem.EmitSoundDyn(m_pPlayer.edict(), CHAN_WEAPON, \"{0}\", 1.0, ATTN_NORM, 0, 95 + Math.RandomLong(0, 10));\r\n\r\n", firesound));
                file.Write("\t\t// player \"shoot\" animation\r\n");
                file.Write("\t\tm_pPlayer.SetAnimation(PLAYER_ATTACK1);\r\n\r\n");
                file.Write("\t\tVector vecSrc = m_pPlayer.GetGunPosition();\r\n");
                file.Write("\t\tVector vecAiming = m_pPlayer.GetAutoaimVector(AUTOAIM_5DEGREES);\r\n\r\n");
                if (weapontype == "shotgun")
                    file.Write(String.Format("\t\tm_pPlayer.FireBullets(4, vecSrc, vecAiming, VECTOR_CONE_5DEGREES, 8192, BULLET_PLAYER_CUSTOMDAMAGE, 2, {0});\r\n\r\n", max_dmg));
                else if (weapontype == "sniper")
                {
                    file.Write("\t\tVector accuracy;\r\n");
                    file.Write("\t\tif (g_iCurrentMode == NOSCOPE)\r\n");
                    file.Write("\t\t{\r\n");
                    file.Write("\t\taccuracy = VECTOR_CONE_5DEGREES;\r\n");
                    file.Write(String.Format("\t\t\tm_pPlayer.FireBullets(1, vecSrc, vecAiming, VECTOR_CONE_5DEGREES, 8192, BULLET_PLAYER_CUSTOMDAMAGE, 4, {0});\r\n", max_dmg));
                    file.Write("\t\t}\r\n");
                    file.Write("\t\telse\r\n");
                    file.Write("\t\t{\r\n");
                    file.Write("\t\taccuracy = VECTOR_CONE_1DEGREES;\r\n");
                    file.Write(String.Format("\t\t\tm_pPlayer.FireBullets(1, vecSrc, vecAiming, VECTOR_CONE_1DEGREES, 8192, BULLET_PLAYER_CUSTOMDAMAGE, 4, {0});\r\n", max_dmg));
                    file.Write("\t\t}\r\n");
                }
                else
                    file.Write(String.Format("\t\tm_pPlayer.FireBullets(1, vecSrc, vecAiming, VECTOR_CONE_6DEGREES, 8192, BULLET_PLAYER_CUSTOMDAMAGE, 2, {0});\r\n\r\n", max_dmg));
                file.Write("\t\tif( self.m_iClip == 0 && m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) <= 0 )\r\n");
                file.Write("\t\t\tm_pPlayer.SetSuitUpdate( \"!HEV_AMO0\", false, 0 );\r\n\r\n");
                file.Write(String.Format("\t\tself.m_flNextPrimaryAttack = g_Engine.time + {0};\r\n", next_attack));
                file.Write("\t\tself.m_flTimeWeaponIdle = g_Engine.time + g_PlayerFuncs.SharedRandomFloat( m_pPlayer.random_seed,  10, 15 );\r\n\r\n");
                if (weapontype == "shotgun")
                {
                    file.Write("\t\tm_fShotgunReload = false;\r\n");
                    file.Write("\t\tm_fPlayPumpSound = true;\r\n");
                    file.Write("\t\tCreatePelletDecals( vecSrc, vecAiming, VECTOR_CONE_DM_SHOTGUN, 8 );\r\n");
                    file.Write("\t\tm_pPlayer.pev.punchangle.x = -5.0;\r\n");
                }
                else
                {
                    file.Write("\t\tTraceResult tr;\r\n");
                    file.Write("\t\tfloat x, y;\r\n");
                    file.Write("\t\tg_Utility.GetCircularGaussianSpread( x, y );\r\n");
                    file.Write("\t\tVector vecDir = vecAiming\r\n");
                    if (weapontype == "sniper")
                    {
                        file.Write("\t\t\t\t\t\t+ x * accuracy.x * g_Engine.v_right \r\n");
                        file.Write("\t\t\t\t\t\t+ y * accuracy.y * g_Engine.v_up;\r\n\r\n");
                    }
                    else
                    {
                        file.Write("\t\t\t\t\t\t+ x * VECTOR_CONE_6DEGREES.x * g_Engine.v_right \r\n");
                        file.Write("\t\t\t\t\t\t+ y * VECTOR_CONE_6DEGREES.y * g_Engine.v_up;\r\n\r\n");
                    }
                    file.Write("\t\tVector vecEnd	= vecSrc + vecDir * 4096;\r\n");
                    file.Write("\t\tg_Utility.TraceLine( vecSrc, vecEnd, dont_ignore_monsters, m_pPlayer.edict(), tr );\r\n");
                    file.Write("\t\tif( tr.flFraction < 1.0 )\r\n");
                    file.Write("\t\t{\r\n");
                    file.Write("\t\t\tif( tr.pHit !is null )\r\n");
                    file.Write("\t\t\t{\r\n");
                    file.Write("\t\t\t\tCBaseEntity@ pHit = g_EntityFuncs.Instance( tr.pHit );\r\n");
                    file.Write("\t\t\t\tif( pHit is null || pHit.IsBSPModel() )\r\n");
                    file.Write("\t\t\t\t\tg_WeaponFuncs.DecalGunshot( tr, BULLET_PLAYER_MP5 );\r\n");
                    file.Write("\t\t\t}\r\n");
                    file.Write("\t\t}\r\n");                    
                }
                file.Write("\t}\r\n");
            }
            else
            {
                // Primary Attack for melee
                file.Write("\t\tif( !Swing( 1 ) )\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tSetThink( ThinkFunction( this.SwingAgain ) );\r\n");
                file.Write("\t\t\tself.pev.nextthink = g_Engine.time + 0.1;\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t}\r\n\r\n");
                // End PrimaryAttack() for melee

                // Smack() function
                file.Write("\tvoid Smack()\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tg_WeaponFuncs.DecalGunshot( m_trHit, BULLET_PLAYER_CROWBAR );\r\n");
                file.Write("\t}\r\n\r\n");
                // End Smack() function

                // SwingAgain() function
                file.Write("\tvoid SwingAgain()\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tSwing( 0 );\r\n");
                file.Write("\t}\r\n");
                // End SwingAgain() function

                // Swing(...) function
                file.Write("\tbool Swing( int fFirst )\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tbool fDidHit = false;\r\n\r\n");
                file.Write("\t\tTraceResult tr;\r\n");
                file.Write("\t\tMath.MakeVectors( m_pPlayer.pev.v_angle );\r\n");
                file.Write("\t\tVector vecSrc = m_pPlayer.GetGunPosition();\r\n");
                file.Write("\t\tVector vecEnd = vecSrc + g_Engine.v_forward * 32;\r\n\r\n");
                file.Write("\t\tg_Utility.TraceLine( vecSrc, vecEnd, dont_ignore_monsters, m_pPlayer.edict(), tr );\r\n");
                file.Write("\t\tif ( tr.flFraction >= 1.0 )\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tg_Utility.TraceHull( vecSrc, vecEnd, dont_ignore_monsters, head_hull, m_pPlayer.edict(), tr );\r\n");
                file.Write("\t\t\tif ( tr.flFraction < 1.0 )\r\n");
                file.Write("\t\t\t\tCBaseEntity@ pHit = g_EntityFuncs.Instance( tr.pHit );\r\n");
                file.Write("\t\t\t\tif ( pHit is null || pHit.IsBSPModel() )\r\n");
                file.Write("\t\t\t\t\tg_Utility.FindHullIntersection(vecSrc, tr, tr, VEC_DUCK_HULL_MIN, VEC_DUCK_HULL_MAX, m_pPlayer.edict());\r\n");
                file.Write("\t\t\t\tvecEnd = tr.vecEndPos;\r\n");
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t\tif ( tr.flFraction >= 1.0 )\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tif( fFirst != 0 )\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write(String.Format("\t\t\t\tself.SendWeaponAnim( {0} );\r\n", missanim));
                file.Write(String.Format("\t\t\t\tself.m_flNextPrimaryAttack = g_Engine.time + {0};\r\n", next_attack));
                file.Write(String.Format("\t\t\t\tg_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_WEAPON, \"{0}\", 1, ATTN_NORM, 0, 94 + Math.RandomLong( 0,0xF ) );\r\n", misssound));
                file.Write("\t\t\t\tm_pPlayer.SetAnimation( PLAYER_ATTACK1 );\r\n");
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t\telse\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tfDidHit = true;\r\n");
                file.Write("\t\t\tCBaseEntity@ pEntity = g_EntityFuncs.Instance( tr.pHit );\r\n");
                file.Write(String.Format("\t\t\tself.SendWeaponAnim( {0} );\r\n", fireanim));
                file.Write("\t\t\tm_pPlayer.SetAnimation( PLAYER_ATTACK1 );\r\n\r\n");
                file.Write("\t\t\tfloat flDamage = self.m_flCustomDmg;\r\n\r\n");
                file.Write("\t\t\tg_WeaponFuncs.ClearMultiDamage();\r\n");
                file.Write("\t\t\tpEntity.TraceAttack( m_pPlayer.pev, flDamage, g_Engine.v_forward, tr, DMG_CLUB );\r\n\r\n");
                file.Write("\t\t\tg_WeaponFuncs.ApplyMultiDamage( m_pPlayer.pev, m_pPlayer.pev );\r\n");
                file.Write("\t\t\tfloat flVol = 1.0;\r\n");
                file.Write("\t\t\tbool fHitWorld = true;\r\n\r\n");
                file.Write("\t\t\tif( pEntity !is null )\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write(String.Format("\t\t\t\tself.m_flNextPrimaryAttack = g_Engine.time + {0}\r\n", next_attack));
                file.Write("\t\t\t\tif( pEntity.Classify() != CLASS_NONE && pEntity.Classify() != CLASS_MACHINE && pEntity.BloodColor() != DONT_BLEED )\r\n");
                file.Write("\t\t\t\t{\r\n");
                file.Write("\t\t\t\t\tif( pEntity.IsPlayer() )\r\n");
                file.Write("\t\t\t\t\t\tpEntity.pev.velocity = pEntity.pev.velocity + ( self.pev.origin - pEntity.pev.origin ).Normalize() * 120;\r\n");
                file.Write("\t\t\t\t\t// play thwack or smack sound\r\n");
                file.Write(String.Format("\t\t\t\t\tg_SoundSystem.EmitSound( m_pPlayer.edict(), CHAN_WEAPON, \"{0}\", 1, ATTN_NORM );\r\n", firesound));
                file.Write("\t\t\t\t\tm_pPlayer.m_iWeaponVolume = 128;\r\n");
                file.Write("\t\t\t\t\tif( !pEntity.IsAlive() )\r\n");
                file.Write("\t\t\t\t\t\treturn true;\r\n");
                file.Write("\t\t\t\t\telse\r\n");
                file.Write("\t\t\t\t\t\tflVol = 0.1;\r\n");
                file.Write("\t\t\t\t\tfHitWorld = false;\r\n");
                file.Write("\t\t\t\t}\r\n");
                file.Write("\t\t\t}\r\n\r\n");
                file.Write("\t\t\tif( fHitWorld == true )\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write("\t\t\t\tfloat fvolbar = g_SoundSystem.PlayHitSound( tr, vecSrc, vecSrc + ( vecEnd - vecSrc ) * 2, BULLET_PLAYER_CROWBAR );\r\n");
                file.Write(String.Format("\t\t\t\tself.m_flNextPrimaryAttack = g_Engine.time +\r\n", next_attack));
                file.Write("\t\t\t\tfvolbar = 1;\r\n");
                file.Write(String.Format("\t\t\t\tg_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_WEAPON, \"{0}\", fvolbar, ATTN_NORM, 0, 98 + Math.RandomLong( 0, 3 ) );\r\n", firesound));
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t\tm_trHit = tr;\r\n");
                file.Write("\t\t\tSetThink( ThinkFunction( this.Smack ) );\r\n");
                file.Write("\t\t\tself.pev.nextthink = g_Engine.time + 0.2;\r\n\r\n");
                file.Write("\t\t\tm_pPlayer.m_iWeaponVolume = int( flVol * 512 );\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t\treturn fDidHit\r\n");
                file.Write("\t}\r\n");
                // End PrimaryAttack() function for melee
            }
            // End PrimaryAttack() function
            
            if (weapontype == "sniper")
            {
                // SetFOV(...) function
                file.Write("\tvoid SetFOV(int fov)\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tm_pPlayer.pev.fov = m_pPlayer.m_iFOV = fov;\r\n");
                file.Write("\t}\r\n");
                // End SetFOV(...) function

                // ToggleZoom(...) function
                file.Write("\tvoid ToggleZoom(int zoomedFOV )\r\n");
                file.Write("\t{\r\n");
                file.Write("\t\tif (self.m_fInZoom == true)\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tSetFOV(0); // 0 means reset to default fov\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t\telse if (self.m_fInZoom == false)\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tSetFOV(zoomedFOV);\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t}\r\n");
                // End ToggleZoom(...) function
            }

            // SecondaryAttack() function
            file.Write("\tvoid SecondaryAttack()\r\n");
            file.Write("\t{\r\n");
            if (weapontype == "sniper")
            {
                file.Write("\t\tself.m_flNextSecondaryAttack = self.m_flNextPrimaryAttack = g_Engine.time + 0.25;\r\n");
                file.Write("\t\tswitch (g_iCurrentMode)\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t\tcase 0:\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write("\t\t\t\tg_iCurrentMode = SCOPE;\r\n");
                file.Write("\t\t\t\tToggleZoom(45);\r\n");
                file.Write("\t\t\t\tm_pPlayer.m_szAnimExtension = \"sniperscope\";\r\n");
                file.Write("\t\t\t\tbreak;\r\n");
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t\tcase 1:\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write("\t\t\t\tg_iCurrentMode = NOSCOPE;\r\n");
                file.Write("\t\t\t\tToggleZoom(0);\r\n");
                file.Write("\t\t\t\tm_pPlayer.m_szAnimExtension = \"sniper\";\r\n");
                file.Write("\t\t\t\tbreak;\r\n");
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t}\r\n");
                file.Write("\t\tg_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_AUTO, ZoomSound, 0.9, ATTN_NORM, 0, PITCH_NORM );\r\n");
            }
            file.Write("\t}\r\n");
            // End SecondaryAttack() function

            // Reload() function
            if (weapontype != "melee")
            {
                file.Write("\tvoid Reload()\r\n");
                file.Write("\t{\r\n");
                if (weapontype != "shotgun")
                {
                    if (weapontype == "sniper")
                    {
                        file.Write("\t\tm_pPlayer.m_szAnimExtension = \"sniper\";\r\n");
                        file.Write("\t\tg_iCurrentMode = NOSCOPE;\r\n");
                        file.Write("\t\tToggleZoom(0);\r\n");
                    }
                    file.Write(String.Format("\t\tself.DefaultReload({0}, {1}, {2:F2}, 0);\r\n",max_clip, reloadanim, reloadspeed));
                }
                else
                {
                    file.Write(String.Format("\t\tif( m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) <= 0 || self.m_iClip == {0} )\r\n", max_clip));
                    file.Write("\t\t\treturn;\r\n\r\n");
                    file.Write("\t\tif( m_flNextReload > g_Engine.time )\r\n");
                    file.Write("\t\t\treturn;\r\n\r\n");
                    file.Write("\t\tif( self.m_flNextPrimaryAttack > g_Engine.time && !m_fShotgunReload )\r\n");
                    file.Write("\t\t\treturn;\r\n\r\n");
                    file.Write("\t\tif( !m_fShotgunReload )\r\n");
                    file.Write("\t\t{\r\n");
                    file.Write(String.Format("\t\t\tself.SendWeaponAnim( {0}, 0, 0 );\r\n", reloadanim));
                    file.Write(String.Format("\t\t\tm_pPlayer.m_flNextAttack = {0};\r\n", next_attack));
                    file.Write("\t\t\tself.m_flTimeWeaponIdle = g_Engine.time + 0.3;\r\n");
                    file.Write(String.Format("\t\t\tself.m_flNextPrimaryAttack 	= g_Engine.time + {0};\r\n", next_attack));
                    file.Write("\t\t\tm_fShotgunReload = true;\r\n");
                    file.Write("\t\t\treturn;\r\n");
                    file.Write("\t\t}\r\n");
                    file.Write("\t\telse if( m_fShotgunReload )\r\n");
                    file.Write("\t\t{\r\n");
                    file.Write("\t\t\tif( self.m_flTimeWeaponIdle > g_Engine.time )\r\n");
                    file.Write("\t\t\t\treturn;\r\n\r\n");
                    file.Write(String.Format("\t\t\tif (self.m_iClip == {0})\r\n", max_clip));
                    file.Write("\t\t\t{\r\n");
                    file.Write("\t\t\t\tm_fShotgunReload = false;\r\n");
                    file.Write("\t\t\t\treturn;\r\n");
                    file.Write("\t\t\t}\r\n");
                    file.Write(String.Format("\t\t\tself.SendWeaponAnim( {0}, 0 );\r\n",reloadanim));
                    file.Write(String.Format("\t\t\tm_flNextReload = g_Engine.time + {0:F2};\r\n", reloadspeed));
                    file.Write(String.Format("\t\t\tself.m_flNextPrimaryAttack 	= g_Engine.time + {0:F2};\r\n", reloadspeed));
                    file.Write(String.Format("\t\t\tself.m_flTimeWeaponIdle = g_Engine.time + {0:F2};\r\n", reloadspeed));
                    file.Write("\t\t\tself.m_iClip += 1;\r\n");
                    file.Write("\t\t\tm_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType, m_pPlayer.m_rgAmmo( self.m_iPrimaryAmmoType ) - 1 );\r\n");
                    file.Write(String.Format("\t\t\tg_SoundSystem.EmitSoundDyn( m_pPlayer.edict(), CHAN_ITEM, \"{0}\", 1, ATTN_NORM, 0, 85 + Math.RandomLong( 0, 0x1f ) );\r\n", reloadsound));
                    file.Write("\t\t}\r\n");
                }
                file.Write("\t\tBaseClass.Reload();\r\n");
                file.Write("\t}\r\n");
            }

            // WeaponIdle() function
            file.Write("\tvoid WeaponIdle()\r\n");
            file.Write("\t{\r\n");
            if (semiauto_checkBox.Checked)
            {
                file.Write("\t\tif (self.m_flNextPrimaryAttack < g_Engine.time)\r\n");
                file.Write("\t\t{\r\n");
                file.Write("\t\t// If the player is still holding the attack button, m_iShotsFired won't reset to 0\r\n");
                file.Write("\t\t// Preventing the automatic firing of the weapon\r\n");
                file.Write("\t\t\tif (!((m_pPlayer.pev.button & IN_ATTACK) != 0))\r\n");
                file.Write("\t\t\t{\r\n");
                file.Write("\t\t\t// Player released the button, reset now\r\n");
                file.Write("\t\t\t\tm_iShotsFired = 0;\r\n");
                file.Write("\t\t\t}\r\n");
                file.Write("\t\t}\r\n");
            }
            file.Write("\t}\r\n");
            // End WeaponIdle() function
            file.Write("}\r\n");
            // Registry functions
            file.Write(String.Format("string Get{0}Name()\r\n" ,shortname));
            file.Write("{\r\n");
            file.Write(String.Format("\treturn \"{0}\";\r\n", weaponname));
            file.Write("}\r\n");
            file.Write(String.Format("void Register{0}()\r\n", shortname));
            file.Write("{\r\n");
            file.Write(String.Format("\tg_CustomEntityFuncs.RegisterCustomEntity( \"{0}\", Get{1}Name() );\r\n", weaponname, shortname));
            file.Write(String.Format("\tg_ItemRegistry.RegisterWeapon( Get{0}Name(), \"\", \"{1}\" );\r\n", shortname, ammotypeBox.Text));
            file.Write("}\r\n");
            file.Close();

            if (hudBox.Text == "Crowbar")
            {
                File.Copy(root + "/sprites/weapon_crowbar.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "Wrench")
            {
                File.Copy(root + "/sprites/weapon_pipewrench.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "9mmhandgun")
            {
                File.Copy(root + "/sprites/weapon_9mmhandgun.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "Revolver")
            {
                File.Copy(root + "/sprites/weapon_357.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "MP5")
            {
                File.Copy(root + "/sprites/weapon_9mmar.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "Spas")
            {
                File.Copy(root + "/sprites/weapon_shotgun.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "M16")
            {
                File.Copy(root + "/sprites/weapon_m16.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "M249")
            {
                File.Copy(root + "/sprites/weapon_m249.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            else if (hudBox.Text == "Uzi")
            {
                File.Copy(root + "/sprites/weapon_uzi.txt", root + String.Format("/sprites/{0}.txt", weaponname), true);
            }
            MessageBox.Show("Success");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
