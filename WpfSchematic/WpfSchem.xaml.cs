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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Data.SqlClient;

namespace WpfSchematic
{
    
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    
    public partial class WpfSchem : UserControl
    {
        public string zam4aP  { get { return zam4aP1.Content.ToString(); } set { zam4aP1.Content = value + " кW"; } }
        public string zam4bP  { get { return zam4bP1.Content.ToString(); } set { zam4bP1.Content = value + " кW"; } }
        public string songinoaP  { get { return songinoaP1.Content.ToString(); } set { songinoaP1.Content = value + " кW"; } }
        public string songinobP  { get { return songinobP1.Content.ToString(); } set { songinobP1.Content = value + " кW"; } }
        public string esgiilehaP  { get { return esgiilehaP1.Content.ToString(); } set { esgiilehaP1.Content = value + " кW"; } }
        public string esgiilehbP { get { return esgiilehbP1.Content.ToString(); } set { esgiilehbP1.Content = value + " кW"; } }
        public string zam4aI { get { return zam4aI1.Content.ToString(); } set { zam4aI1.Content = value + " A"; } }
        public string zam4bI { get { return zam4bI1.Content.ToString(); } set { zam4bI1.Content = value + " A"; } }
        public string songinoaI { get { return songinoaI1.Content.ToString(); } set { songinoaI1.Content = value + " A"; } }
        public string songinobI { get { return songinobI1.Content.ToString(); } set { songinobI1.Content = value + " A"; } }
        public string esgiilehaI { get { return esgiilehaI1.Content.ToString(); } set { esgiilehaI1.Content = value + " A"; } }
        public string esgiilehbI { get { return esgiilehbI1.Content.ToString(); } set { esgiilehbI1.Content = value + " A"; } }
        public string TG1U { get { return TG1U1.Content.ToString(); } set { TG1U1.Content = value + " В"; } }
        public string TG1I { get { return TG1I1.Content.ToString(); } set { TG1I1.Content = value + " A"; } }
        public string TG1P { get { return TG1P1.Content.ToString(); } set { TG1P1.Content = value + " mВт"; } }
        public string TG1Q { get { return TG1Q1.Content.ToString(); } set { TG1Q1.Content = value + " mВар"; } }
        public string TG1PF { get { return TG1PF1.Content.ToString(); } set { TG1PF1.Content = value + " "; } }
        public string TG2U { get { return TG2U1.Content.ToString(); } set { TG2U1.Content = value + " В"; } }
        public string TG2I { get { return TG2I1.Content.ToString(); } set { TG2I1.Content = value + " A"; } }
        public string TG2P { get { return TG2P1.Content.ToString(); } set { TG2P1.Content = value + " mВт"; } }
        public string TG2Q { get { return TG2Q1.Content.ToString(); } set { TG2Q1.Content = value + " mВар"; } }
        public string TG2PF { get { return TG2PF1.Content.ToString(); } set { TG2PF1.Content = value + " "; } }
        public string TG3U { get { return TG3U1.Content.ToString(); } set { TG3U1.Content = value + " В"; } }
        public string TG3I { get { return TG3I1.Content.ToString(); } set { TG3I1.Content = value + " A"; } }
        public string TG3P { get { return TG3P1.Content.ToString(); } set { TG3P1.Content = value + " mВт"; } }
        public string TG3Q { get { return TG3Q1.Content.ToString(); } set { TG3Q1.Content = value + " mВар"; } }
        public string TG3PF { get { return TG3PF1.Content.ToString(); } set { TG3PF1.Content = value + " "; } }
        public string TG4U { get { return TG4U1.Content.ToString(); } set { TG4U1.Content = value + " В"; } }
        public string TG4I { get { return TG4I1.Content.ToString(); } set { TG4I1.Content = value + " A"; } }
        public string TG4P { get { return TG4P1.Content.ToString(); } set { TG4P1.Content = value + " mВт"; } }
        public string TG4Q { get { return TG4Q1.Content.ToString(); } set { TG4Q1.Content = value + " mВар"; } }
        public string TG4PF { get { return TG4PF1.Content.ToString(); } set { TG4PF1.Content = value + " "; } }
        public string TG5U { get { return TG5U1.Content.ToString(); } set { TG5U1.Content = value + " В"; } }
        public string TG5I { get { return TG5I1.Content.ToString(); } set { TG5I1.Content = value + " A"; } }
        public string TG5P { get { return TG5P1.Content.ToString(); } set { TG5P1.Content = value + " mВт"; } }
        public string TG5Q { get { return TG5Q1.Content.ToString(); } set { TG5Q1.Content = value + " mВар"; } }
        public string TG5PF { get { return TG5PF1.Content.ToString(); } set { TG5PF1.Content = value + " "; } }
        public string TG6U { get { return TG6U1.Content.ToString(); } set { TG6U1.Content = value + " В"; } }
        public string TG6I { get { return TG6I1.Content.ToString(); } set { TG6I1.Content = value + " A"; } }
        public string TG6P { get { return TG6P1.Content.ToString(); } set { TG6P1.Content = value + " mВт"; } }
        public string TG6Q { get { return TG6Q1.Content.ToString(); } set { TG6Q1.Content = value + " mВар"; } }
        public string TG6PF { get { return TG6PF1.Content.ToString(); } set { TG6PF1.Content = value + " "; } }
        public string TG7U { get { return TG7U1.Content.ToString(); } set { TG7U1.Content = value + " В"; } }
        public string TG7I { get { return TG7I1.Content.ToString(); } set { TG7I1.Content = value + " A"; } }
        public string TG7P { get { return TG7P1.Content.ToString(); } set { TG7P1.Content = value + " mВт"; } }
        public string TG7Q { get { return TG7Q1.Content.ToString(); } set { TG7Q1.Content = value + " mВар"; } }
        public string TG7PF { get { return TG7PF1.Content.ToString(); } set { TG7PF1.Content = value + " "; } }
        public string TG8U { get { return TG8U1.Content.ToString(); } set { TG8U1.Content = value + " В"; } }
        public string TG8I { get { return TG8I1.Content.ToString(); } set { TG8I1.Content = value + " A"; } }
        public string TG8P { get { return TG8P1.Content.ToString(); } set { TG8P1.Content = value + " mВт"; } }
        public string TG8Q { get { return TG8Q1.Content.ToString(); } set { TG8Q1.Content = value + " mВар"; } }
        public string TG8PF { get { return TG8PF1.Content.ToString(); } set { TG8PF1.Content = value + " "; } }
        public string TG9P { get { return TG9P1.Content.ToString(); } set { TG9P1.Content = value + " mВт"; } }


        public string BTR5U { get { return BTR5U1.Content.ToString(); } set { BTR5U1.Content = value + " В"; } }
        public string BTR5I { get { return BTR5I1.Content.ToString(); } set { BTR5I1.Content = value + " A"; } }
        public string BTR5P { get { return BTR5P1.Content.ToString(); } set { BTR5P1.Content = value + " mВт"; } }
        public string BTR5Q { get { return BTR5Q1.Content.ToString(); } set { BTR5Q1.Content = value + " mВар"; } }
        public string BTR5PF { get { return BTR5PF1.Content.ToString(); } set { BTR5PF1.Content = value + " "; } }
        public string BTR6U { get { return BTR6U1.Content.ToString(); } set { BTR6U1.Content = value + " В"; } }
        public string BTR6I { get { return BTR6I1.Content.ToString(); } set { BTR6I1.Content = value + " A"; } }
        public string BTR6P { get { return BTR6P1.Content.ToString(); } set { BTR6P1.Content = value + " mВт"; } }
        public string BTR6Q { get { return BTR6Q1.Content.ToString(); } set { BTR6Q1.Content = value + " mВар"; } }
        public string BTR6PF { get { return BTR6PF1.Content.ToString(); } set { BTR6PF1.Content = value + " "; } }
        public string BTR7U { get { return BTR7U1.Content.ToString(); } set { BTR7U1.Content = value + " В"; } }
        public string BTR7I { get { return BTR7I1.Content.ToString(); } set { BTR7I1.Content = value + " A"; } }
        public string BTR7P { get { return BTR7P1.Content.ToString(); } set { BTR7P1.Content = value + " mВт"; } }
        public string BTR7Q { get { return BTR7Q1.Content.ToString(); } set { BTR7Q1.Content = value + " mВар"; } }
        public string BTR7PF { get { return BTR7PF1.Content.ToString(); } set { BTR7PF1.Content = value + " "; } }
        public string BTR8U { get { return BTR8U1.Content.ToString(); } set { BTR8U1.Content = value + " В"; } }
        public string BTR8I { get { return BTR8I1.Content.ToString(); } set { BTR8I1.Content = value + " A"; } }
        public string BTR8P { get { return BTR8P1.Content.ToString(); } set { BTR8P1.Content = value + " mВт"; } }
        public string BTR8Q { get { return BTR8Q1.Content.ToString(); } set { BTR8Q1.Content = value + " mВар"; } }
        public string BTR8PF { get { return BTR8PF1.Content.ToString(); } set { BTR8PF1.Content = value + " "; } }


        public string R1roaU { get { return R1roaU1.Content.ToString(); } set { R1roaU1.Content = value + " В"; } }
        public string R1roaI { get { return R1roaI1.Content.ToString(); } set { R1roaI1.Content = value + " A"; } }
        public string R1roaP { get { return R1roaP1.Content.ToString(); } set { R1roaP1.Content = value + " кВт"; } }
        public string R1roaQ { get { return R1roaQ1.Content.ToString(); } set { R1roaQ1.Content = value + " кВар"; } }
        public string R1roaPF { get { return R1roaPF1.Content.ToString(); } set { R1roaPF1.Content = value + " "; } }
        public string R1robU { get { return R1robU1.Content.ToString(); } set { R1robU1.Content = value + " В"; } }
        public string R1robI { get { return R1robI1.Content.ToString(); } set { R1robI1.Content = value + " A"; } }
        public string R1robP { get { return R1robP1.Content.ToString(); } set { R1robP1.Content = value + " кВт"; } }
        public string R1robQ { get { return R1robQ1.Content.ToString(); } set { R1robQ1.Content = value + " кВар"; } }
        public string R1robPF { get { return R1robPF1.Content.ToString(); } set { R1robPF1.Content = value + " "; } }
        public string R7raU { get { return R7raU1.Content.ToString(); } set { R7raU1.Content = value + " В"; } }
        public string R7raI { get { return R7raI1.Content.ToString(); } set { R7raI1.Content = value + " A"; } }
        public string R7raP { get { return R7raP1.Content.ToString(); } set { R7raP1.Content = value + " кВт"; } }
        public string R7raQ { get { return R7raQ1.Content.ToString(); } set { R7raQ1.Content = value + " кВар"; } }
        public string R7raPF { get { return R7raPF1.Content.ToString(); } set { R7raPF1.Content = value + " "; } }
        public string R7rbU { get { return R7rbU1.Content.ToString(); } set { R7rbU1.Content = value + " В"; } }
        public string R7rbI { get { return R7rbI1.Content.ToString(); } set { R7rbI1.Content = value + " A"; } }
        public string R7rbP { get { return R7rbP1.Content.ToString(); } set { R7rbP1.Content = value + " кВт"; } }
        public string R7rbQ { get { return R7rbQ1.Content.ToString(); } set { R7rbQ1.Content = value + " кВар"; } }
        public string R7rbPF { get { return R7rbPF1.Content.ToString(); } set { R7rbPF1.Content = value + " "; } }

        public string R2roaU { get { return R2roaU1.Content.ToString(); } set { R2roaU1.Content = value + " В"; } }
        public string R2roaI { get { return R2roaI1.Content.ToString(); } set { R2roaI1.Content = value + " A"; } }
        public string R2roaP { get { return R2roaP1.Content.ToString(); } set { R2roaP1.Content = value + " кВт"; } }
        public string R2roaQ { get { return R2roaQ1.Content.ToString(); } set { R2roaQ1.Content = value + " кВар"; } }
        public string R2roaPF { get { return R2roaPF1.Content.ToString(); } set { R2roaPF1.Content = value + " "; } }
        public string R2robU { get { return R2robU1.Content.ToString(); } set { R2robU1.Content = value + " В"; } }
        public string R2robI { get { return R2robI1.Content.ToString(); } set { R2robI1.Content = value + " A"; } }
        public string R2robP { get { return R2robP1.Content.ToString(); } set { R2robP1.Content = value + " кВт"; } }
        public string R2robQ { get { return R2robQ1.Content.ToString(); } set { R2robQ1.Content = value + " кВар"; } }
        public string R2robPF { get { return R2robPF1.Content.ToString(); } set { R2robPF1.Content = value + " "; } }
        public string R8raU { get { return R8raU1.Content.ToString(); } set { R8raU1.Content = value + " В"; } }
        public string R8raI { get { return R8raI1.Content.ToString(); } set { R8raI1.Content = value + " A"; } }
        public string R8raP { get { return R8raP1.Content.ToString(); } set { R8raP1.Content = value + " кВт"; } }
        public string R8raQ { get { return R8raQ1.Content.ToString(); } set { R8raQ1.Content = value + " кВар"; } }
        public string R8raPF { get { return R8raPF1.Content.ToString(); } set { R8raPF1.Content = value + " "; } }
        public string R8rbU { get { return R8rbU1.Content.ToString(); } set { R8rbU1.Content = value + " В"; } }
        public string R8rbI { get { return R8rbI1.Content.ToString(); } set { R8rbI1.Content = value + " A"; } }
        public string R8rbP { get { return R8rbP1.Content.ToString(); } set { R8rbP1.Content = value + " кВт"; } }
        public string R8rbQ { get { return R8rbQ1.Content.ToString(); } set { R8rbQ1.Content = value + " кВар"; } }
        public string R8rbPF { get { return R8rbPF1.Content.ToString(); } set { R8rbPF1.Content = value + " "; } }

        public string R9raU { get { return R9raU1.Content.ToString(); } set { R9raU1.Content = value + " В"; } }
        public string R9raI { get { return R9raI1.Content.ToString(); } set { R9raI1.Content = value + " A"; } }
        public string R9raP { get { return R9raP1.Content.ToString(); } set { R9raP1.Content = value + " кВт"; } }
        public string R9raQ { get { return R9raQ1.Content.ToString(); } set { R9raQ1.Content = value + " кВар"; } }
        public string R9raPF { get { return R9raPF1.Content.ToString(); } set { R9raPF1.Content = value + " "; } }
        public string R9rbU { get { return R9rbU1.Content.ToString(); } set { R9rbU1.Content = value + " В"; } }
        public string R9rbI { get { return R9rbI1.Content.ToString(); } set { R9rbI1.Content = value + " A"; } }
        public string R9rbP { get { return R9rbP1.Content.ToString(); } set { R9rbP1.Content = value + " кВт"; } }
        public string R9rbQ { get { return R9rbQ1.Content.ToString(); } set { R9rbQ1.Content = value + " кВар"; } }
        public string R9rbPF { get { return R9rbPF1.Content.ToString(); } set { R9rbPF1.Content = value + " "; } }
        public string R10raU { get { return R10raU1.Content.ToString(); } set { R10raU1.Content = value + " В"; } }
        public string R10raI { get { return R10raI1.Content.ToString(); } set { R10raI1.Content = value + " A"; } }
        public string R10raP { get { return R10raP1.Content.ToString(); } set { R10raP1.Content = value + " кВт"; } }
        public string R10raQ { get { return R10raQ1.Content.ToString(); } set { R10raQ1.Content = value + " кВар"; } }
        public string R10raPF { get { return R10raPF1.Content.ToString(); } set { R10raPF1.Content = value + " "; } }
        public string R10rbU { get { return R10rbU1.Content.ToString(); } set { R10rbU1.Content = value + " В"; } }
        public string R10rbI { get { return R10rbI1.Content.ToString(); } set { R10rbI1.Content = value + " A"; } }
        public string R10rbP { get { return R10rbP1.Content.ToString(); } set { R10rbP1.Content = value + " кВт"; } }
        public string R10rbQ { get { return R10rbQ1.Content.ToString(); } set { R10rbQ1.Content = value + " кВар"; } }
        public string R10rbPF { get { return R10rbPF1.Content.ToString(); } set { R10rbPF1.Content = value + " "; } }

        public string R11raU { get { return R11raU1.Content.ToString(); } set { R11raU1.Content = value + " В"; } }
        public string R11raI { get { return R11raI1.Content.ToString(); } set { R11raI1.Content = value + " A"; } }
        public string R11raP { get { return R11raP1.Content.ToString(); } set { R11raP1.Content = value + " кВт"; } }
        public string R11raQ { get { return R11raQ1.Content.ToString(); } set { R11raQ1.Content = value + " кВар"; } }
        public string R11raPF { get { return R11raPF1.Content.ToString(); } set { R11raPF1.Content = value + " "; } }
        public string R11rbU { get { return R11rbU1.Content.ToString(); } set { R11rbU1.Content = value + " В"; } }
        public string R11rbI { get { return R11rbI1.Content.ToString(); } set { R11rbI1.Content = value + " A"; } }
        public string R11rbP { get { return R11rbP1.Content.ToString(); } set { R11rbP1.Content = value + " кВт"; } }
        public string R11rbQ { get { return R11rbQ1.Content.ToString(); } set { R11rbQ1.Content = value + " кВар"; } }
        public string R11rbPF { get { return R11rbPF1.Content.ToString(); } set { R11rbPF1.Content = value + " "; } }
        public string R12raU { get { return R12raU1.Content.ToString(); } set { R12raU1.Content = value + " В"; } }
        public string R12raI { get { return R12raI1.Content.ToString(); } set { R12raI1.Content = value + " A"; } }
        public string R12raP { get { return R12raP1.Content.ToString(); } set { R12raP1.Content = value + " кВт"; } }
        public string R12raQ { get { return R12raQ1.Content.ToString(); } set { R12raQ1.Content = value + " кВар"; } }
        public string R12raPF { get { return R12raPF1.Content.ToString(); } set { R12raPF1.Content = value + " "; } }
        public string R12rbU { get { return R12rbU1.Content.ToString(); } set { R12rbU1.Content = value + " В"; } }
        public string R12rbI { get { return R12rbI1.Content.ToString(); } set { R12rbI1.Content = value + " A"; } }
        public string R12rbP { get { return R12rbP1.Content.ToString(); } set { R12rbP1.Content = value + " кВт"; } }
        public string R12rbQ { get { return R12rbQ1.Content.ToString(); } set { R12rbQ1.Content = value + " кВар"; } }
        public string R12rbPF { get { return R12rbPF1.Content.ToString(); } set { R12rbPF1.Content = value + " "; } }

        public string R13raU { get { return R13raU1.Content.ToString(); } set { R13raU1.Content = value + " В"; } }
        public string R13raI { get { return R13raI1.Content.ToString(); } set { R13raI1.Content = value + " A"; } }
        public string R13raP { get { return R13raP1.Content.ToString(); } set { R13raP1.Content = value + " кВт"; } }
        public string R13raQ { get { return R13raQ1.Content.ToString(); } set { R13raQ1.Content = value + " кВар"; } }
        public string R13raPF { get { return R13raPF1.Content.ToString(); } set { R13raPF1.Content = value + " "; } }

        public string R13rbU { get { return R13rbU1.Content.ToString(); } set { R13rbU1.Content = value + " В"; } }
        public string R13rbI { get { return R13rbI1.Content.ToString(); } set { R13rbI1.Content = value + " A"; } }
        public string R13rbP { get { return R13rbP1.Content.ToString(); } set { R13rbP1.Content = value + " кВт"; } }
        public string R13rbQ { get { return R13rbQ1.Content.ToString(); } set { R13rbQ1.Content = value + " кВар"; } }
        public string R13rbPF { get { return R13rbPF1.Content.ToString(); } set { R13rbPF1.Content = value + " "; } }


        public string T12U { get { return T12U1.Content.ToString(); } set { T12U1.Content = value + " В"; } }
        public string T12I { get { return T12I1.Content.ToString(); } set { T12I1.Content = value + " A"; } }
        public string T12P { get { return T12P1.Content.ToString(); } set { T12P1.Content = value + " кВт"; } }
        public string T12Q { get { return T12Q1.Content.ToString(); } set { T12Q1.Content = value + " кВар"; } }
        public string T12PF { get { return T12PF1.Content.ToString(); } set { T12PF1.Content = value + " "; } }


        public string ao1U { get { return ao1U1.Content.ToString(); } set { ao1U1.Content = value + " В"; } }
        public string ao1I { get { return ao1I1.Content.ToString(); } set { ao1I1.Content = value + " A"; } }
        public string ao1P { get { return ao1P1.Content.ToString(); } set { ao1P1.Content = value + " кВт"; } }
        public string ao1Q { get { return ao1Q1.Content.ToString(); } set { ao1Q1.Content = value + " кВар"; } }
        public string ao1PF { get { return ao1PF1.Content.ToString(); } set { ao1PF1.Content = value + " "; } }

        public string ao2U { get { return ao2U1.Content.ToString(); } set { ao2U1.Content = value + " В"; } }
        public string ao2I { get { return ao2I1.Content.ToString(); } set { ao2I1.Content = value + " A"; } }
        public string ao2P { get { return ao2P1.Content.ToString(); } set { ao2P1.Content = value + " кВт"; } }
        public string ao2Q { get { return ao2Q1.Content.ToString(); } set { ao2Q1.Content = value + " кВар"; } }
        public string ao2PF { get { return ao2PF1.Content.ToString(); } set { ao2PF1.Content = value + " "; } }

        public string ao3U { get { return ao3U1.Content.ToString(); } set { ao3U1.Content = value + " В"; } }
        public string ao3I { get { return ao3I1.Content.ToString(); } set { ao3I1.Content = value + " A"; } }
        public string ao3P { get { return ao3P1.Content.ToString(); } set { ao3P1.Content = value + " кВт"; } }
        public string ao3Q { get { return ao3Q1.Content.ToString(); } set { ao3Q1.Content = value + " кВар"; } }
        public string ao3PF { get { return ao3PF1.Content.ToString(); } set { ao3PF1.Content = value + " "; } }

        public string ao4U { get { return ao4U1.Content.ToString(); } set { ao4U1.Content = value + " В"; } }
        public string ao4I { get { return ao4I1.Content.ToString(); } set { ao4I1.Content = value + " A"; } }
        public string ao4P { get { return ao4P1.Content.ToString(); } set { ao4P1.Content = value + " кВт"; } }
        public string ao4Q { get { return ao4Q1.Content.ToString(); } set { ao4Q1.Content = value + " кВар"; } }
        public string ao4PF { get { return ao4PF1.Content.ToString(); } set { ao4PF1.Content = value + " "; } }

        public string ao5U { get { return ao5U1.Content.ToString(); } set { ao5U1.Content = value + " В"; } }
        public string ao5I { get { return ao5I1.Content.ToString(); } set { ao5I1.Content = value + " A"; } }
        public string ao5P { get { return ao5P1.Content.ToString(); } set { ao5P1.Content = value + " кВт"; } }
        public string ao5Q { get { return ao5Q1.Content.ToString(); } set { ao5Q1.Content = value + " кВар"; } }
        public string ao5PF { get { return ao5PF1.Content.ToString(); } set { ao5PF1.Content = value + " "; } }
        public string ao6U { get { return ao6U1.Content.ToString(); } set { ao6U1.Content = value + " В"; } }
        public string ao6I { get { return ao6I1.Content.ToString(); } set { ao6I1.Content = value + " A"; } }
        public string ao6P { get { return ao6P1.Content.ToString(); } set { ao6P1.Content = value + " кВт"; } }
        public string ao6Q { get { return ao6Q1.Content.ToString(); } set { ao6Q1.Content = value + " кВар"; } }
        public string ao6PF { get { return ao6PF1.Content.ToString(); } set { ao6PF1.Content = value + " "; } }

        public string T1U { get { return T1U1.Content.ToString(); } set { T1U1.Content = value + " В"; } }
        public string T1I { get { return T1I1.Content.ToString(); } set { T1I1.Content = value + " A"; } }
        public string T1P { get { return T1P1.Content.ToString(); } set { T1P1.Content = value + " кВт"; } }
        public string T1Q { get { return T1Q1.Content.ToString(); } set { T1Q1.Content = value + " кВар"; } }
        public string T1PF { get { return T1PF1.Content.ToString(); } set { T1PF1.Content = value + " "; } }

        public string T2U { get { return T2U1.Content.ToString(); } set { T2U1.Content = value + " В"; } }
        public string T2I { get { return T2I1.Content.ToString(); } set { T2I1.Content = value + " A"; } }
        public string T2P { get { return T2P1.Content.ToString(); } set { T2P1.Content = value + " кВт"; } }
        public string T2Q { get { return T2Q1.Content.ToString(); } set { T2Q1.Content = value + " кВар"; } }
        public string T2PF { get { return T2PF1.Content.ToString(); } set { T2PF1.Content = value + " "; } }

        public string YCHU { get { return YCHU1.Content.ToString(); } set { YCHU1.Content = value + " В"; } }
        public string YCHI { get { return YCHI1.Content.ToString(); } set { YCHI1.Content = value + " A"; } }
        public string YCHP { get { return YCHP1.Content.ToString(); } set { YCHP1.Content = value + " кВт"; } }
        public string YCHQ { get { return YCHQ1.Content.ToString(); } set { YCHQ1.Content = value + " кВар"; } }
        public string YCHPF { get { return YCHPF1.Content.ToString(); } set { YCHPF1.Content = value + " "; } }

        public string T10U { get { return T10U1.Content.ToString(); } set { T10U1.Content = value + " В"; } }
        public string T10I { get { return T10I1.Content.ToString(); } set { T10I1.Content = value + " A"; } }
        public string T10P { get { return T10P1.Content.ToString(); } set { T10P1.Content = value + " кВт"; } }
        public string T10Q { get { return T10Q1.Content.ToString(); } set { T10Q1.Content = value + " кВар"; } }
        public string T10PF { get { return T10PF1.Content.ToString(); } set { T10PF1.Content = value + " "; } }

        public string blDateStart { get { return blDateStart1.Text.ToString(); } set { blDateStart1.Text = value; } }
        public string blDateStop { get { return blDateStop1.Text.ToString(); } set { blDateStop1.Text = value; } }
        public string L110BL { get { return L110BL1.Content.ToString(); } set { L110BL1.Content = "110кВ-ЫН ШИН БЛ: " + value + " % "; } }
        public string L35BL { get { return L35BL1.Content.ToString(); } set { L35BL1.Content = value + " %"; } }
        public string BTR5BL { get { return BTR5BL1.Content.ToString(); } set { BTR5BL1.Content = "БЛ: " + value + " % "; } }
        public string BTR6BL { get { return BTR6BL1.Content.ToString(); } set { BTR6BL1.Content = "БЛ: " + value + " % "; } }
        public string BTR7BL { get { return BTR7BL1.Content.ToString(); } set { BTR7BL1.Content = "БЛ: " + value + " % "; } }
        public string BTR8BL { get { return BTR8BL1.Content.ToString(); } set { BTR8BL1.Content = "БЛ: " + value + " % "; } }
        public string BTR9BL { get { return BTR9BL1.Content.ToString(); } set { BTR9BL1.Content = "БЛ: " + value + " % "; } }
        public string BL1RO { get { return BL1RO1.Content.ToString(); } set { BL1RO1.Content = "БЛ: " + value + " % "; } }
        public string BL7R { get { return BL7R1.Content.ToString(); } set { BL7R1.Content = "БЛ: " + value + " % "; } }
        public string BL2RO { get { return BL2RO1.Content.ToString(); } set { BL2RO1.Content = "БЛ: " + value + " % "; } }
        public string BL8R { get { return BL8R1.Content.ToString(); } set { BL8R1.Content = "БЛ: " + value + " % "; } }
        public string BL9R { get { return BL9R1.Content.ToString(); } set { BL9R1.Content = "БЛ: " + value + " % "; } }
        public string BL10R { get { return BL10R1.Content.ToString(); } set { BL10R1.Content = "БЛ: " + value + " % "; } }
        public string BL11R { get { return BL11R1.Content.ToString(); } set { BL11R1.Content = "БЛ: " + value + " % "; } }
        public string BL12R { get { return BL12R1.Content.ToString(); } set { BL12R1.Content = "БЛ: " + value + " % "; } }
        public string BL13R { get { return BL13R1.Content.ToString(); } set { BL13R1.Content = "БЛ: " + value + " % "; } }
        public string UDS_BELTGEL_SHIN_BL { get { return UDS_BELTGEL_SHIN_BL1.Content.ToString(); } set { UDS_BELTGEL_SHIN_BL1.Content = "БЛ: " + value + " % "; } }
        public string T12BL { get { return T12BL1.Content.ToString(); } set { T12BL1.Content = "БЛ:" + value + " % "; } }
        public string GRU6kVBL { get { return GRU6kVBL1.Content.ToString(); } set { GRU6kVBL1.Content = "БЛ: " + value + " % "; } }
        public string BL1R { get { return BL1R1.Content.ToString(); } set { BL1R1.Content = "БЛ: " + value + " % "; } }
        public string BL2R { get { return BL2R1.Content.ToString(); } set { BL2R1.Content = "БЛ: " + value + " % "; } }
        public string BL3R { get { return BL3R1.Content.ToString(); } set { BL3R1.Content = "БЛ: " + value + " % "; } }
        public string BL4R { get { return BL4R1.Content.ToString(); } set { BL4R1.Content = "БЛ: " + value + " % "; } }
        public string BL5R { get { return BL5R1.Content.ToString(); } set { BL5R1.Content = "БЛ: " + value + " % "; } }
        public string BL6R { get { return BL6R1.Content.ToString(); } set { BL6R1.Content = "БЛ: " + value + " % "; } }
        public string Dund_Real_P { get { return Dund_Real_P1.Content.ToString(); } set { Dund_Real_P1.Content = "Дунд P: " + value + " мВт "; } }
        public string Undur_Real_P { get { return Undur_Real_P1.Content.ToString(); } set { Undur_Real_P1.Content = "Өндөр Р: " + value + " мВт "; } }
        public string Niit_Real_P { get { return Niit_Real_P1.Content.ToString(); } set { Niit_Real_P1.Content = "Нийт Р: " + value + " мВт "; } }
        //public bool Read_balance { get { return false; } set { Read_balance = value; } }
        public bool balanceSelectTime = false;
        public int TG1
        {
            set {
                if (value == 1) { TG1tasluur.Visibility = Visibility.Visible; tg[1] = 1; }
                else if (value == 2) { TG1tasluur.Visibility = Visibility.Hidden; tg[1] = 0; }
                else { TG1tasluur.Visibility = Visibility.Hidden; tg[1] = 0; }
            }
        }
        public int TG2
        {
            set {
                if (value == 1) { TG2tasluur.Visibility = Visibility.Visible; tg[2] = 1; }
                else if (value == 2) { TG2tasluur.Visibility = Visibility.Hidden; tg[2] = 0; }
                else { TG2tasluur.Visibility = Visibility.Hidden; tg[2] = 0; }
            }
        }
        public int TG3
        {
            set {
                if (value == 1) { TG3tasluur.Visibility = Visibility.Visible; tg[3] = 1; }
                else if (value == 2) { TG3tasluur.Visibility = Visibility.Hidden; tg[3] = 0; }
                else { TG3tasluur.Visibility = Visibility.Hidden; tg[3] = 0; }
            }
        }
        public int TG4
        {
            set {
                if (value == 1) { tg4tasluur.Visibility = Visibility.Visible; tg[4] = 1; }
                else if (value == 2) { tg4tasluur.Visibility = Visibility.Hidden; tg[4] = 0; }
                else { tg4tasluur.Visibility = Visibility.Hidden; tg[4] = 0; }
            }
        }
        public int TG5
        {
            set
            {
                if (value == 1) { TG5tasluur.Visibility = Visibility.Visible; TG5line.Visibility = Visibility.Visible; tg[5] = 1; }
                else if (value == 2) { TG5tasluur.Visibility = Visibility.Hidden; TG5line.Visibility = Visibility.Hidden; tg[5] = 0; }
                else { TG5tasluur.Visibility = Visibility.Hidden; TG5line.Visibility = Visibility.Hidden; tg[5] = 0; }
            }
        }
        public int TG6
        {
            set
            {
                if (value == 1) { TG6tasluur.Visibility = Visibility.Visible; TG6line.Visibility = Visibility.Visible; tg[6] = 1; }
                else if (value == 2) { TG6tasluur.Visibility = Visibility.Hidden; TG6line.Visibility = Visibility.Hidden; tg[6] = 0; }
                else { TG6tasluur.Visibility = Visibility.Hidden; TG6line.Visibility = Visibility.Hidden; tg[6] = 0; }
            }
        }
        public int TG7
        {
            set
            {
                if (value == 1) { TG7tasluur.Visibility = Visibility.Visible; TG7line.Visibility = Visibility.Visible; tg[7] = 1; }
                else if (value == 2) { TG7tasluur.Visibility = Visibility.Hidden; TG7line.Visibility = Visibility.Hidden; tg[7] = 0; }
                else { TG7tasluur.Visibility = Visibility.Hidden; TG7line.Visibility = Visibility.Hidden; tg[7] = 0; }
            }
        }
        public int TG8
        {
            set
            {
                if (value == 1) { TG8tasluur.Visibility = Visibility.Visible; TG8line.Visibility = Visibility.Visible; tg[8] = 1; }
                else if (value == 2) { TG8tasluur.Visibility = Visibility.Hidden; TG8line.Visibility = Visibility.Hidden; tg[8] = 0; }
                else { TG8tasluur.Visibility = Visibility.Hidden; TG8line.Visibility = Visibility.Hidden; tg[8] = 0; }
            }
        }
        public int TG9
        {
            set { if (value == 1) { TG9tasuur.Visibility = Visibility.Visible; tg[9] = 1; } else if (value == 2) { TG9tasuur.Visibility = Visibility.Hidden; tg[9] = 0; } else { TG9tasuur.Visibility = Visibility.Hidden; tg[9] = 0; } }
        }
        public int R1roa
        {
            set
            {
                if (value == 1) { R1roared.Visibility = Visibility.Visible; R1roaline.Visibility = Visibility.Visible; R1roagreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R1roared.Visibility = Visibility.Hidden; R1roaline.Visibility = Visibility.Hidden; R1roagreen.Visibility = Visibility.Visible; }
                else { R1roared.Visibility = Visibility.Hidden; R1roaline.Visibility = Visibility.Hidden; R1roagreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R1rob
        {
            set
            {
                if (value == 1) { R1robred.Visibility = Visibility.Visible; R1robline.Visibility = Visibility.Visible; R1robgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R1robred.Visibility = Visibility.Hidden; R1robline.Visibility = Visibility.Hidden; R1robgreen.Visibility = Visibility.Visible; }
                else { R1robred.Visibility = Visibility.Hidden; R1robline.Visibility = Visibility.Hidden; R1robgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R7ra
        {
            set
            {
                if (value == 1) { R7rared.Visibility = Visibility.Visible; R7raline.Visibility = Visibility.Visible; R7ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R7rared.Visibility = Visibility.Hidden; R7raline.Visibility = Visibility.Hidden; R7ragreen.Visibility = Visibility.Visible; }
                else { R7rared.Visibility = Visibility.Hidden; R7raline.Visibility = Visibility.Hidden; R7ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R7rb
        {
            set
            {
                if (value == 1) { R7rbred.Visibility = Visibility.Visible; R7rbline.Visibility = Visibility.Visible; R7rbgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R7rbred.Visibility = Visibility.Hidden; R7rbline.Visibility = Visibility.Hidden; R7rbgreen.Visibility = Visibility.Visible; }
                else { R7rbred.Visibility = Visibility.Hidden; R7rbline.Visibility = Visibility.Hidden; R7rbgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R2roa
        {
            set
            {
                if (value == 1) { R2roared.Visibility = Visibility.Visible; R2roaline.Visibility = Visibility.Visible; R2roagreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R2roared.Visibility = Visibility.Hidden; R2roaline.Visibility = Visibility.Hidden; R2roagreen.Visibility = Visibility.Visible; }
                else { R2roared.Visibility = Visibility.Hidden; R2roaline.Visibility = Visibility.Hidden; R2roagreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R2rob
        {
            set
            {
                if (value == 1) { R2robred.Visibility = Visibility.Visible; R2robline.Visibility = Visibility.Visible; R2robgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R2robred.Visibility = Visibility.Hidden; R2robline.Visibility = Visibility.Hidden; R2robgreen.Visibility = Visibility.Visible; }
                else { R2robred.Visibility = Visibility.Hidden; R2robline.Visibility = Visibility.Hidden; R2robgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R8ra
        {
            set
            {
                if (value == 1) { R8rared.Visibility = Visibility.Visible; R8raline.Visibility = Visibility.Visible; R8ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R8rared.Visibility = Visibility.Hidden; R8raline.Visibility = Visibility.Hidden; R8ragreen.Visibility = Visibility.Visible; }
                else { R8rared.Visibility = Visibility.Hidden; R8raline.Visibility = Visibility.Hidden; R8ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R8rb
        {
            set
            {
                if (value == 1) { R8rbred.Visibility = Visibility.Visible; R8rbline.Visibility = Visibility.Visible; R8rbgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R8rbred.Visibility = Visibility.Hidden; R8rbline.Visibility = Visibility.Hidden; R8rbgreen.Visibility = Visibility.Visible; }
                else { R8rbred.Visibility = Visibility.Hidden; R8rbline.Visibility = Visibility.Hidden; R8rbgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R9ra
        {
            set
            {
                if (value == 1) { R9rared.Visibility = Visibility.Visible; R9line.Visibility = Visibility.Visible; R9ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R9rared.Visibility = Visibility.Hidden; R9line.Visibility = Visibility.Hidden; R9ragreen.Visibility = Visibility.Visible; }
                else { R9rared.Visibility = Visibility.Hidden; R9line.Visibility = Visibility.Hidden; R9ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R9rb
        {
            set
            {
                if (value == 1) { R9rbred.Visibility = Visibility.Visible; R9rbline.Visibility = Visibility.Visible; R9rbgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R9rbred.Visibility = Visibility.Hidden; R9rbline.Visibility = Visibility.Hidden; R9rbgreen.Visibility = Visibility.Visible; }
                else { R9rbred.Visibility = Visibility.Hidden; R9rbline.Visibility = Visibility.Hidden; R9rbgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R10ra
        {
            set
            {
                if (value == 1) { R10rared.Visibility = Visibility.Visible; R10raline.Visibility = Visibility.Visible; R10ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R10rared.Visibility = Visibility.Hidden; R10raline.Visibility = Visibility.Hidden; R10ragreen.Visibility = Visibility.Visible; }
                else { R10rared.Visibility = Visibility.Hidden; R10raline.Visibility = Visibility.Hidden; R10ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R10rb
        {
            set
            {
                if (value == 1) { R10rbred.Visibility = Visibility.Visible; R10rbline.Visibility = Visibility.Visible; R10rbgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R10rbred.Visibility = Visibility.Hidden; R10rbline.Visibility = Visibility.Hidden; R10rbgreen.Visibility = Visibility.Visible; }
                else { R10rbred.Visibility = Visibility.Hidden; R10rbline.Visibility = Visibility.Hidden; R10rbgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R11ra
        {
            set
            {
                if (value == 1) { R11rared.Visibility = Visibility.Visible; R11raline.Visibility = Visibility.Visible; R11ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R11rared.Visibility = Visibility.Hidden; R11raline.Visibility = Visibility.Hidden; R11ragreen.Visibility = Visibility.Visible; }
                else { R11rared.Visibility = Visibility.Hidden; R11raline.Visibility = Visibility.Hidden; R11ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R11rb
        {
            set
            {
                if (value == 1) { R11rbred.Visibility = Visibility.Visible; R11rbline.Visibility = Visibility.Visible; R11rbgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R11rbred.Visibility = Visibility.Hidden; R11rbline.Visibility = Visibility.Hidden; R11rbgreen.Visibility = Visibility.Visible; }
                else { R11rbred.Visibility = Visibility.Hidden; R11rbline.Visibility = Visibility.Hidden; R11rbgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R12ra
        {
            set
            {
                if (value == 1) { R12rared.Visibility = Visibility.Visible; R12raline.Visibility = Visibility.Visible; R12ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R12rared.Visibility = Visibility.Hidden; R12raline.Visibility = Visibility.Hidden; R12ragreen.Visibility = Visibility.Visible; }
                else { R12rared.Visibility = Visibility.Hidden; R12raline.Visibility = Visibility.Hidden; R12ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R12rb
        {
            set
            {
                if (value == 1) { R12rbred.Visibility = Visibility.Visible; R12rbline.Visibility = Visibility.Visible; R12rbgreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R12rbred.Visibility = Visibility.Hidden; R12rbline.Visibility = Visibility.Hidden; R12rbgreen.Visibility = Visibility.Visible; }
                else { R12rbred.Visibility = Visibility.Hidden; R12rbline.Visibility = Visibility.Hidden; R12rbgreen.Visibility = Visibility.Hidden; }
            }
        }
        public int R13ra
        {
            set
            {
                if (value == 1) { R13rared.Visibility = Visibility.Visible; R13raline.Visibility = Visibility.Visible; R13ragreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { R13rared.Visibility = Visibility.Hidden; R13raline.Visibility = Visibility.Hidden; R13ragreen.Visibility = Visibility.Visible; }
                else { R13rared.Visibility = Visibility.Hidden; R13raline.Visibility = Visibility.Hidden; R13ragreen.Visibility = Visibility.Hidden; }
            }
        }
        public int T12
        {
            set
            {
                if (value == 1)
                { T12red.Visibility = Visibility.Visible; T12line.Visibility = Visibility.Visible; T12green.Visibility = Visibility.Hidden; }
                else if (value == 2)
                { T12red.Visibility = Visibility.Hidden; T12line.Visibility = Visibility.Hidden; T12green.Visibility = Visibility.Visible; }
                else { T12red.Visibility = Visibility.Hidden; T12line.Visibility = Visibility.Hidden; T12green.Visibility = Visibility.Hidden; }
            }
        }
        public int P76
        {
            set { if (value == 1) { pic76.Visibility = Visibility.Visible; } else if (value == 2) { pic76.Visibility = Visibility.Hidden; } else { pic76.Visibility = Visibility.Hidden; } }
        }
        public int P79
        {
            set { if (value == 1) { pic79.Visibility = Visibility.Visible; } else if (value == 2) { pic79.Visibility = Visibility.Hidden; } else { pic79.Visibility = Visibility.Hidden; } }
        }
        public int P77
        {
            set { if (value == 1) { pic77.Visibility = Visibility.Visible; } else if (value == 2) { pic77.Visibility = Visibility.Hidden; } else { pic77.Visibility = Visibility.Hidden; } }
        }
        public int P78
        {
            set { if (value == 1) { pic78.Visibility = Visibility.Visible; } else if (value == 2) { pic78.Visibility = Visibility.Hidden; } else { pic78.Visibility = Visibility.Hidden; } }
        }
        public int P80
        {
            set { if (value == 1) { pic80.Visibility = Visibility.Visible; } else if (value == 2) { pic80.Visibility = Visibility.Hidden; } else { pic80.Visibility = Visibility.Hidden; } }
        }
        public int P82
        {
            set { if (value == 1) { pic82.Visibility = Visibility.Visible; } else if (value == 2) { pic82.Visibility = Visibility.Hidden; } else { pic82.Visibility = Visibility.Hidden; } }
        }
        public int P81
        {
            set { if (value == 1) { pic81.Visibility = Visibility.Visible; } else if (value == 2) { pic81.Visibility = Visibility.Hidden; } else { pic81.Visibility = Visibility.Hidden; } }
        }
        public int P84
        {
            set { if (value == 1) { pic84.Visibility = Visibility.Visible; } else if (value == 2) { pic77.Visibility = Visibility.Hidden; } else { pic77.Visibility = Visibility.Hidden; } }
        }
        public int ao1
        {
            set
            {
                if (value == 1) { ao1red.Visibility = Visibility.Visible; ao1line.Visibility = Visibility.Visible; ao1green.Visibility = Visibility.Hidden; }
                else if (value == 2) { ao1red.Visibility = Visibility.Hidden; ao1line.Visibility = Visibility.Hidden; ao1green.Visibility = Visibility.Visible; }
                else { ao1red.Visibility = Visibility.Hidden; ao1line.Visibility = Visibility.Hidden; ao1green.Visibility = Visibility.Hidden; }
            }
        }
        public int ao2
        {
            set
            {
                if (value == 1) { ao2red.Visibility = Visibility.Visible; ao2line.Visibility = Visibility.Visible; ao2green.Visibility = Visibility.Hidden; }
                else if (value == 2) { ao2red.Visibility = Visibility.Hidden; ao2line.Visibility = Visibility.Hidden; ao2green.Visibility = Visibility.Visible; }
                else { ao2red.Visibility = Visibility.Hidden; ao2line.Visibility = Visibility.Hidden; ao2green.Visibility = Visibility.Hidden; }
            }
        }
        public int ao3
        {
            set
            {
                if (value == 1) { ao3red.Visibility = Visibility.Visible; ao3line.Visibility = Visibility.Visible; ao3green.Visibility = Visibility.Hidden; }
                else if (value == 2) { ao3red.Visibility = Visibility.Hidden; ao3line.Visibility = Visibility.Hidden; ao3green.Visibility = Visibility.Visible; }
                else { ao3red.Visibility = Visibility.Hidden; ao3line.Visibility = Visibility.Hidden; ao3green.Visibility = Visibility.Hidden; }
            }
        }
        public int ao4
        {
            set
            {
                if (value == 1) { ao4red.Visibility = Visibility.Visible; ao4line.Visibility = Visibility.Visible; ao4green.Visibility = Visibility.Hidden; }
                else if (value == 2) { ao4red.Visibility = Visibility.Hidden; ao4line.Visibility = Visibility.Hidden; ao4green.Visibility = Visibility.Visible; }
                else { ao4red.Visibility = Visibility.Hidden; ao4line.Visibility = Visibility.Hidden; ao4green.Visibility = Visibility.Hidden; }
            }
        }
        public int ao5
        {
            set
            {
                if (value == 1) { ao5red.Visibility = Visibility.Visible; ao5line.Visibility = Visibility.Visible; ao5green.Visibility = Visibility.Hidden; }
                else if (value == 2) { ao5red.Visibility = Visibility.Hidden; ao5line.Visibility = Visibility.Hidden; ao5green.Visibility = Visibility.Visible; }
                else { ao5red.Visibility = Visibility.Hidden; ao5line.Visibility = Visibility.Hidden; ao5green.Visibility = Visibility.Hidden; }
            }
        }
        public int ao6
        {
            set
            {
                if (value == 1) { ao6red.Visibility = Visibility.Visible; ao6line.Visibility = Visibility.Visible; ao6green.Visibility = Visibility.Hidden; }
                else if (value == 2) { ao6red.Visibility = Visibility.Hidden; ao6line.Visibility = Visibility.Hidden; ao6green.Visibility = Visibility.Visible; }
                else { ao6red.Visibility = Visibility.Hidden; ao6line.Visibility = Visibility.Hidden; ao6green.Visibility = Visibility.Hidden; }
            }
        }
        public int T1l
        {
            set { if (value == 1) { T1line.Visibility = Visibility.Visible; }
                else if (value == 2) { T1line.Visibility = Visibility.Hidden; }
                else { T1line.Visibility = Visibility.Hidden; } }
        }
        public int T2l
        {
            set { if (value == 1) { T2line.Visibility = Visibility.Visible; } else if (value == 2) { T2line.Visibility = Visibility.Hidden; } else { T2line.Visibility = Visibility.Hidden; } }
        }
        public int T12_110l
        {
            set { if (value == 1) { T12_110.Visibility = Visibility.Visible; } else if (value == 2) { T12_110.Visibility = Visibility.Hidden; } else { T12_110.Visibility = Visibility.Hidden; } }
        }
        public int L105l
        {
            set { if (value == 1) { L105.Visibility = Visibility.Visible; } else if (value == 2) { L105.Visibility = Visibility.Hidden; } else { L105.Visibility = Visibility.Hidden; } }
        }
        public int L106l
        {
            set { if (value == 1) { L106.Visibility = Visibility.Visible; } else if (value == 2) { L106.Visibility = Visibility.Hidden; } else { L106.Visibility = Visibility.Hidden; } }
        }
        public int toirogl
        {
            set { if (value == 1) { toirog.Visibility = Visibility.Visible; } else if (value == 2) { toirog.Visibility = Visibility.Hidden; } else { toirog.Visibility = Visibility.Hidden; } }
        }
        public int holbogch_11kVl
        {
            set { if (value == 1) { holbogch_11kV.Visibility = Visibility.Visible; } else if (value == 2) { holbogch_11kV.Visibility = Visibility.Hidden; } else { holbogch_11kV.Visibility = Visibility.Hidden; } }
        }
        public int uildverl
        {
            set { if (value == 1) { uildver.Visibility = Visibility.Visible; } else if (value == 2) { uildver.Visibility = Visibility.Hidden; } else { uildver.Visibility = Visibility.Hidden; } }
        }
        public int T2_110kVl
        {
            set { if (value == 1) { T2_110kV.Visibility = Visibility.Visible; } else if (value == 2) { T2_110kV.Visibility = Visibility.Hidden; } else { T2_110kV.Visibility = Visibility.Hidden; } }
        }
        public int L111l
        {
            set { if (value == 1) { L111.Visibility = Visibility.Visible; } else if (value == 2) { L111.Visibility = Visibility.Hidden; } else { L111.Visibility = Visibility.Hidden; } }
        }
        public int L112l
        {
            set { if (value == 1) { L112.Visibility = Visibility.Visible; } else if (value == 2) { L112.Visibility = Visibility.Hidden; } else { L112.Visibility = Visibility.Hidden; } }
        }
        public int T1_110kVl
        {
            set { if (value == 1) { T1_110kV.Visibility = Visibility.Visible; } else if (value == 2) { T1_110kV.Visibility = Visibility.Hidden; } else { T1_110kV.Visibility = Visibility.Hidden; } }
        }
        public int holboo_al
        {
            set { if (value == 1) { holboo_a.Visibility = Visibility.Visible; } else if (value == 2) { holboo_a.Visibility = Visibility.Hidden; } else { holboo_a.Visibility = Visibility.Hidden; } }
        }
        public int t1_35l
        {
            set { if (value == 1) { t1_35.Visibility = Visibility.Visible; } else if (value == 2) { t1_35.Visibility = Visibility.Hidden; } else { t1_35.Visibility = Visibility.Hidden; } }
        }
        public int holboo_bl
        {
            set { if (value == 1) { holboo_b.Visibility = Visibility.Visible; } else if (value == 2) { holboo_b.Visibility = Visibility.Hidden; } else { holboo_b.Visibility = Visibility.Hidden; } }
        }
        public int esgiileh_al
        {
            set { if (value == 1) { esgiileh_a.Visibility = Visibility.Visible; } else if (value == 2) { esgiileh_a.Visibility = Visibility.Hidden; } else { esgiileh_a.Visibility = Visibility.Hidden; } }
        }
        public int esgiileh_bl
        {
            set { if (value == 1) { esgiileh_b.Visibility = Visibility.Visible; } else if (value == 2) { esgiileh_b.Visibility = Visibility.Hidden; } else { esgiileh_b.Visibility = Visibility.Hidden; } }
        }
        public int t2_35l
        {
            set { if (value == 1) { t2_35.Visibility = Visibility.Visible; } else if (value == 2) { t2_35.Visibility = Visibility.Hidden; } else { t2_35.Visibility = Visibility.Hidden; } }
        }
        public int songino_al
        {
            set { if (value == 1) { songino_a.Visibility = Visibility.Visible; } else if (value == 2) { songino_a.Visibility = Visibility.Hidden; } else { songino_a.Visibility = Visibility.Hidden; } }
        }
        public int songino_bl
        {
            set { if (value == 1) { songino_b.Visibility = Visibility.Visible; } else if (value == 2) { songino_b.Visibility = Visibility.Hidden; } else { songino_b.Visibility = Visibility.Hidden; } }
        }
        public int L4zam_al
        {
            set { if (value == 1) { ash4zam_a.Visibility = Visibility.Visible; } else if (value == 2) { ash4zam_a.Visibility = Visibility.Hidden; } else { ash4zam_a.Visibility = Visibility.Hidden; } }
        }
        public int L4zam_bl
        {
            set { if (value == 1) { ash4zam_b.Visibility = Visibility.Visible; } else if (value == 2) { ash4zam_b.Visibility = Visibility.Hidden; } else { ash4zam_b.Visibility = Visibility.Hidden; } }
        }
        public int t10_35l
        {
            set { if (value == 1) { t10_35.Visibility = Visibility.Visible; }
                else if (value == 2) { t10_35.Visibility = Visibility.Hidden; }
                else { t10_35.Visibility = Visibility.Hidden; }
            }
        }
        public int T2_6kVl
        {
            set { if (value == 1) { T2_6kV.Visibility = Visibility.Visible; } else if (value == 2) { T2_6kV.Visibility = Visibility.Hidden; } else { T2_6kV.Visibility = Visibility.Hidden; } }
        }
        public int T1_6kVl
        {
            set { if (value == 1) { T1_6kV.Visibility = Visibility.Visible; } else if (value == 2) { T1_6kV.Visibility = Visibility.Hidden; } else { T1_6kV.Visibility = Visibility.Hidden; } }
        }
        public int gru1l
        {
            set { if (value == 1) { gru1.Visibility = Visibility.Visible; } else if (value == 2) { gru1.Visibility = Visibility.Hidden; } else { gru1.Visibility = Visibility.Hidden; } }
        }
        public int gru2l
        {
            set { if (value == 1) { gru2.Visibility = Visibility.Visible; } else if (value == 2) { gru2.Visibility = Visibility.Hidden; } else { gru2.Visibility = Visibility.Hidden; } }
        }
        public int T10l
        {
            set
            {
                if (value == 1) { T10lineRed.Visibility = Visibility.Visible; T10lineGreen.Visibility = Visibility.Hidden; }
                else if (value == 2) { T10lineRed.Visibility = Visibility.Hidden; T10lineGreen.Visibility = Visibility.Visible; }
                else { T10lineRed.Visibility = Visibility.Hidden; T10lineGreen.Visibility = Visibility.Hidden; }
            }
        }
        public int Ych53_13BO
        {
            set
            {
                if (value == 1) { Yach53LineRed.Visibility = Visibility.Visible; Yach53LineGreen.Visibility = Visibility.Hidden; Ych53red.Visibility = Visibility.Visible; Ych53green.Visibility = Visibility.Hidden; BO_13red.Visibility = Visibility.Visible; BO_13green.Visibility = Visibility.Hidden; }
                else if (value == 2) { Yach53LineRed.Visibility = Visibility.Hidden; Yach53LineGreen.Visibility = Visibility.Visible; Ych53red.Visibility = Visibility.Hidden; Ych53green.Visibility = Visibility.Visible; BO_13red.Visibility = Visibility.Hidden; BO_13green.Visibility = Visibility.Visible; }
                else { Yach53LineRed.Visibility = Visibility.Hidden; Yach53LineGreen.Visibility = Visibility.Hidden; Ych53red.Visibility = Visibility.Hidden; Ych53green.Visibility = Visibility.Hidden; BO_13red.Visibility = Visibility.Hidden; BO_13green.Visibility = Visibility.Hidden; }
            }
        }
        public int Ych04
        {
            set
            {
                if (value == 1) { Ych04LineRed.Visibility = Visibility.Visible; Ych04LineRed.Visibility = Visibility.Hidden; Ych04red.Visibility = Visibility.Visible; Ych04green.Visibility = Visibility.Hidden; }
                else if (value == 2) { Ych04LineRed.Visibility = Visibility.Hidden; Ych04LineRed.Visibility = Visibility.Visible; Ych04red.Visibility = Visibility.Hidden; Ych04green.Visibility = Visibility.Visible; }
                else { Ych04LineRed.Visibility = Visibility.Hidden; Ych04LineRed.Visibility = Visibility.Hidden; Ych04red.Visibility = Visibility.Hidden; Ych04green.Visibility = Visibility.Hidden; }
            }
        }
        public WpfSchem()
        {
            InitializeComponent();
            
            read();
        }

        private void read()
        {
            DispatcherTimer timertsahi = new DispatcherTimer();
            timertsahi.Interval = new TimeSpan(0, 0, 0, 0, 500);
            timertsahi.Tick += read;
            timertsahi.Start();
        }

        float[] tg = new float[20];
        float[,] tg1 = new float[20, 20];

        private void read(object sender, EventArgs e)
        {
            if (tg[1] == 1)
            {
                //  MessageBox.Show(tg1[5, 0].ToString());
                TG1_bg.Visibility = Visibility.Visible;
                if (tg1[1, 0] == 0)
                {
                    tg1[1, 0] = 1;
                    TG1_f1.Visibility = Visibility.Visible;
                    TG1_f2.Visibility = Visibility.Hidden;
                    TG1_f3.Visibility = Visibility.Hidden;
                    TG1_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[1, 0] == 1)
                {
                    tg1[1, 0] = 2;
                    TG1_f1.Visibility = Visibility.Hidden;
                    TG1_f2.Visibility = Visibility.Visible;
                    TG1_f3.Visibility = Visibility.Hidden;
                    TG1_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[1, 0] == 2)
                {
                    tg1[1, 0] = 3;
                    TG1_f1.Visibility = Visibility.Hidden;
                    TG1_f2.Visibility = Visibility.Hidden;
                    TG1_f3.Visibility = Visibility.Visible;
                    TG1_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[1, 0] == 3)
                {
                    tg1[1, 0] = 0;
                    TG1_f1.Visibility = Visibility.Hidden;
                    TG1_f2.Visibility = Visibility.Hidden;
                    TG1_f3.Visibility = Visibility.Hidden;
                    TG1_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[1] == 0)
            {
                TG1_bg.Visibility = Visibility.Hidden;
                TG1_f1.Visibility = Visibility.Hidden;
                TG1_f2.Visibility = Visibility.Hidden;
                TG1_f3.Visibility = Visibility.Hidden;
                TG1_f4.Visibility = Visibility.Hidden;

            }

            if (tg[2] == 1)
            {
                //  MessageBox.Show(tg1[5, 0].ToString());
                TG2_bg.Visibility = Visibility.Visible;
                if (tg1[2, 0] == 0)
                {
                    tg1[2, 0] = 1;
                    TG2_f1.Visibility = Visibility.Visible;
                    TG2_f2.Visibility = Visibility.Hidden;
                    TG2_f3.Visibility = Visibility.Hidden;
                    TG2_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[2, 0] == 1)
                {
                    tg1[2, 0] = 2;
                    TG2_f1.Visibility = Visibility.Hidden;
                    TG2_f2.Visibility = Visibility.Visible;
                    TG2_f3.Visibility = Visibility.Hidden;
                    TG2_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[2, 0] == 2)
                {
                    tg1[2, 0] = 3;
                    TG2_f1.Visibility = Visibility.Hidden;
                    TG2_f2.Visibility = Visibility.Hidden;
                    TG2_f3.Visibility = Visibility.Visible;
                    TG2_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[2, 0] == 3)
                {
                    tg1[2, 0] = 0;
                    TG2_f1.Visibility = Visibility.Hidden;
                    TG2_f2.Visibility = Visibility.Hidden;
                    TG2_f3.Visibility = Visibility.Hidden;
                    TG2_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[2] == 0)
            {
                TG2_bg.Visibility = Visibility.Hidden;
                TG2_f1.Visibility = Visibility.Hidden;
                TG2_f2.Visibility = Visibility.Hidden;
                TG2_f3.Visibility = Visibility.Hidden;
                TG2_f4.Visibility = Visibility.Hidden;

            }

            if (tg[3] == 1)
            {
                //  MessageBox.Show(tg1[5, 0].ToString());
                TG3_bg.Visibility = Visibility.Visible;
                if (tg1[3, 0] == 0)
                {
                    tg1[3, 0] = 1;
                    TG3_f1.Visibility = Visibility.Visible;
                    TG3_f2.Visibility = Visibility.Hidden;
                    TG3_f3.Visibility = Visibility.Hidden;
                    TG3_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[3, 0] == 1)
                {
                    tg1[3, 0] = 2;
                    TG3_f1.Visibility = Visibility.Hidden;
                    TG3_f2.Visibility = Visibility.Visible;
                    TG3_f3.Visibility = Visibility.Hidden;
                    TG3_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[3, 0] == 2)
                {
                    tg1[3, 0] = 3;
                    TG3_f1.Visibility = Visibility.Hidden;
                    TG3_f2.Visibility = Visibility.Hidden;
                    TG3_f3.Visibility = Visibility.Visible;
                    TG3_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[3, 0] == 3)
                {
                    tg1[3, 0] = 0;
                    TG3_f1.Visibility = Visibility.Hidden;
                    TG3_f2.Visibility = Visibility.Hidden;
                    TG3_f3.Visibility = Visibility.Hidden;
                    TG3_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[3] == 0)
            {
                TG3_bg.Visibility = Visibility.Hidden;
                TG3_f1.Visibility = Visibility.Hidden;
                TG3_f2.Visibility = Visibility.Hidden;
                TG3_f3.Visibility = Visibility.Hidden;
                TG3_f4.Visibility = Visibility.Hidden;

            }


            if (tg[4] == 1)
            {
                //  MessageBox.Show(tg1[5, 0].ToString());
                TG4_bg.Visibility = Visibility.Visible;
                if (tg1[4, 0] == 0)
                {
                    tg1[4, 0] = 1;
                    TG4_f1.Visibility = Visibility.Visible;
                    TG4_f2.Visibility = Visibility.Hidden;
                    TG4_f3.Visibility = Visibility.Hidden;
                    TG4_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[4, 0] == 1)
                {
                    tg1[4, 0] = 2;
                    TG4_f1.Visibility = Visibility.Hidden;
                    TG4_f2.Visibility = Visibility.Visible;
                    TG4_f3.Visibility = Visibility.Hidden;
                    TG4_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[4, 0] == 2)
                {
                    tg1[4, 0] = 3;
                    TG4_f1.Visibility = Visibility.Hidden;
                    TG4_f2.Visibility = Visibility.Hidden;
                    TG4_f3.Visibility = Visibility.Visible;
                    TG4_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[4, 0] == 3)
                {
                    tg1[4, 0] = 0;
                    TG4_f1.Visibility = Visibility.Hidden;
                    TG4_f2.Visibility = Visibility.Hidden;
                    TG4_f3.Visibility = Visibility.Hidden;
                    TG4_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[4] == 0)
            {
                TG4_bg.Visibility = Visibility.Hidden;
                TG4_f1.Visibility = Visibility.Hidden;
                TG4_f2.Visibility = Visibility.Hidden;
                TG4_f3.Visibility = Visibility.Hidden;
                TG4_f4.Visibility = Visibility.Hidden;

            }

            if (tg[5] == 1)
            {
                //  MessageBox.Show(tg1[5, 0].ToString());
                TG5_bg.Visibility = Visibility.Visible;
                if (tg1[5, 0] == 0)
                {
                    tg1[5, 0] = 1;
                    TG5_f1.Visibility = Visibility.Visible;
                    TG5_f2.Visibility = Visibility.Hidden;
                    TG5_f3.Visibility = Visibility.Hidden;
                    TG5_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[5, 0] == 1)
                {
                    tg1[5, 0] = 2;
                    TG5_f1.Visibility = Visibility.Hidden;
                    TG5_f2.Visibility = Visibility.Visible;
                    TG5_f3.Visibility = Visibility.Hidden;
                    TG5_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[5, 0] == 2)
                {
                    tg1[5, 0] = 3;
                    TG5_f1.Visibility = Visibility.Hidden;
                    TG5_f2.Visibility = Visibility.Hidden;
                    TG5_f3.Visibility = Visibility.Visible;
                    TG5_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[5, 0] == 3)
                {
                    tg1[5, 0] = 0;
                    TG5_f1.Visibility = Visibility.Hidden;
                    TG5_f2.Visibility = Visibility.Hidden;
                    TG5_f3.Visibility = Visibility.Hidden;
                    TG5_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[5] == 0)
            {
                TG5_bg.Visibility = Visibility.Hidden;
                TG5_f1.Visibility = Visibility.Hidden;
                TG5_f2.Visibility = Visibility.Hidden;
                TG5_f3.Visibility = Visibility.Hidden;
                TG5_f4.Visibility = Visibility.Hidden;

            }


            if (tg[6] == 1)
            {
                //  MessageBox.Show(tg1[6, 0].ToString());
                TG6_bg.Visibility = Visibility.Visible;
                if (tg1[6, 0] == 0)
                {
                    tg1[6, 0] = 1;
                    TG6_f1.Visibility = Visibility.Visible;
                    TG6_f2.Visibility = Visibility.Hidden;
                    TG6_f3.Visibility = Visibility.Hidden;
                    TG6_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[6, 0] == 1)
                {
                    tg1[6, 0] = 2;
                    TG6_f1.Visibility = Visibility.Hidden;
                    TG6_f2.Visibility = Visibility.Visible;
                    TG6_f3.Visibility = Visibility.Hidden;
                    TG6_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[6, 0] == 2)
                {
                    tg1[6, 0] = 3;
                    TG6_f1.Visibility = Visibility.Hidden;
                    TG6_f2.Visibility = Visibility.Hidden;
                    TG6_f3.Visibility = Visibility.Visible;
                    TG6_f4.Visibility = Visibility.Hidden;
                }

                else if (tg1[6, 0] == 3)
                {
                    tg1[6, 0] = 0;
                    TG6_f1.Visibility = Visibility.Hidden;
                    TG6_f2.Visibility = Visibility.Hidden;
                    TG6_f3.Visibility = Visibility.Hidden;
                    TG6_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[6] == 0)
            {
                TG6_bg.Visibility = Visibility.Hidden;
                TG6_f1.Visibility = Visibility.Hidden;
                TG6_f2.Visibility = Visibility.Hidden;
                TG6_f3.Visibility = Visibility.Hidden;
                TG6_f4.Visibility = Visibility.Hidden;
            }
            if (tg[7] == 1)
            {
                //  MessageBox.Show(tg1[7, 0].ToString());
                TG7_bg.Visibility = Visibility.Visible;
                if (tg1[7, 0] == 0)
                {
                    tg1[7, 0] = 1;
                    TG7_f1.Visibility = Visibility.Visible;
                    TG7_f2.Visibility = Visibility.Hidden;
                    TG7_f3.Visibility = Visibility.Hidden;
                    TG7_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[7, 0] == 1)
                {
                    tg1[7, 0] = 2;
                    TG7_f1.Visibility = Visibility.Hidden;
                    TG7_f2.Visibility = Visibility.Visible;
                    TG7_f3.Visibility = Visibility.Hidden;
                    TG7_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[7, 0] == 2)
                {
                    tg1[7, 0] = 3;
                    TG7_f1.Visibility = Visibility.Hidden;
                    TG7_f2.Visibility = Visibility.Hidden;
                    TG7_f3.Visibility = Visibility.Visible;
                    TG7_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[7, 0] == 3)
                {
                    tg1[7, 0] = 0;
                    TG7_f1.Visibility = Visibility.Hidden;
                    TG7_f2.Visibility = Visibility.Hidden;
                    TG7_f3.Visibility = Visibility.Hidden;
                    TG7_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[7] == 0)
            {
                TG7_bg.Visibility = Visibility.Hidden;
                TG7_f1.Visibility = Visibility.Hidden;
                TG7_f2.Visibility = Visibility.Hidden;
                TG7_f3.Visibility = Visibility.Hidden;
                TG7_f4.Visibility = Visibility.Hidden;

            }

            if (tg[8] == 1)
            {
                //  MessageBox.Show(tg1[8, 0].ToString());
                TG8_bg.Visibility = Visibility.Visible;
                if (tg1[8, 0] == 0)
                {
                    tg1[8, 0] = 1;

                    TG8_f1.Visibility = Visibility.Visible;
                    TG8_f2.Visibility = Visibility.Hidden;
                    TG8_f3.Visibility = Visibility.Hidden;
                    TG8_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[8, 0] == 1)
                {
                    tg1[8, 0] = 2;
                    TG8_f1.Visibility = Visibility.Hidden;
                    TG8_f2.Visibility = Visibility.Visible;
                    TG8_f3.Visibility = Visibility.Hidden;
                    TG8_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[8, 0] == 2)
                {
                    tg1[8, 0] = 3;
                    TG8_f1.Visibility = Visibility.Hidden;
                    TG8_f2.Visibility = Visibility.Hidden;
                    TG8_f3.Visibility = Visibility.Visible;
                    TG8_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[8, 0] == 3)
                {
                    tg1[8, 0] = 0;
                    TG8_f1.Visibility = Visibility.Hidden;
                    TG8_f2.Visibility = Visibility.Hidden;
                    TG8_f3.Visibility = Visibility.Hidden;
                    TG8_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[8] == 0)
            {
                TG8_bg.Visibility = Visibility.Hidden;
                TG8_f1.Visibility = Visibility.Hidden;
                TG8_f2.Visibility = Visibility.Hidden;
                TG8_f3.Visibility = Visibility.Hidden;
                TG8_f4.Visibility = Visibility.Hidden;

            }

            if (tg[9] == 1)
            {
                //  MessageBox.Show(tg1[9, 0].ToString());
                TG9_bg.Visibility = Visibility.Visible;
                if (tg1[9, 0] == 0)
                {
                    tg1[9, 0] = 1;
                    TG9_f1.Visibility = Visibility.Visible;
                    TG9_f2.Visibility = Visibility.Hidden;
                    TG9_f3.Visibility = Visibility.Hidden;
                    TG9_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[9, 0] == 1)
                {
                    tg1[9, 0] = 2;
                    TG9_f1.Visibility = Visibility.Hidden;
                    TG9_f2.Visibility = Visibility.Visible;
                    TG9_f3.Visibility = Visibility.Hidden;
                    TG9_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[9, 0] == 2)
                {
                    tg1[9, 0] = 3;
                    TG9_f1.Visibility = Visibility.Hidden;
                    TG9_f2.Visibility = Visibility.Hidden;
                    TG9_f3.Visibility = Visibility.Visible;
                    TG9_f4.Visibility = Visibility.Hidden;
                }
                else if (tg1[9, 0] == 3)
                {
                    tg1[9, 0] = 0;
                    TG9_f1.Visibility = Visibility.Hidden;
                    TG9_f2.Visibility = Visibility.Hidden;
                    TG9_f3.Visibility = Visibility.Hidden;
                    TG9_f4.Visibility = Visibility.Visible;
                }
            }
            if (tg[9] == 0)
            {
                TG9_bg.Visibility = Visibility.Hidden;
                TG9_f1.Visibility = Visibility.Hidden;
                TG9_f2.Visibility = Visibility.Hidden;
                TG9_f3.Visibility = Visibility.Hidden;
                TG9_f4.Visibility = Visibility.Hidden;

            }
        }

        public event EventHandler BalanceBodoh;

        private void blansBodoh_click(object sender, RoutedEventArgs e)
        {
            if (BalanceBodoh != null)
                BalanceBodoh(sender, e);
        }
    }
}
