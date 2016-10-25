using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Microsoft.Office.Core;
//using Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1
{
    
    public partial class Form1 : Form
    {
        
        Form GPIO = new Form() { Size = new Size(400, 200),AutoSize =true, MaximizeBox = false, Text = "GPIO"};
        Button GPIO_Input = new Button() { Text = "IN", AutoSize = true, Location = new Point(80, 110), Size = new Size(), Enabled = true };
        Button GPIO_output = new Button() { Text = "OUT", AutoSize = true, Location = new Point(220, 110), Size = new Size(), Enabled = true };
        Button resistor_enable = new Button() { Text = "IN", AutoSize = true, Location = new Point(80, 110), Size = new Size(), Enabled = true };
        Button resistor_disable = new Button() { Text = "OUT", AutoSize = true, Location = new Point(220, 110), Size = new Size(), Enabled = true }; Label LABEL1 = new Label() { };
        Button uart_tx= new Button() { Text = "Uart_Tx", AutoSize = true, Location = new Point(80, 110), Size = new Size(), Enabled = true };
        Button uart_rx = new Button() { Text = "Uart_Rx", AutoSize = true, Location = new Point(220, 110), Size = new Size(), Enabled = true };
        public string selc,internref,inorout;
        public int row_number = 0,i;
        public int port, bit;
        public List<string> port_init_statements = new List<string>();
        public List<string> port_mapping_statements = new List<string>();
        public List<string> vref_statements = new List<string>();
        public int[] analog_pins = new int[9] { 1, 2, 3, 4, 5, 6, 34, 35, 36 };
        // { 17, 18, 25, 26, 27, 32, 33, 37, 40 } pin numbers have been excluded from the list as they are reserved
        public int[] total_pins = new int[31] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 19, 20, 21, 22, 23, 24, 28, 29, 30, 31, 34, 35, 36, 38, 39 }; 
        public Form1()
        {
            InitializeComponent();
           
            
            foreach (var element in (dynamic)total_pins)
            {
               gpio_pins_selc.Items.Add(element); // add available pins for selection
               uart_pins_selc.Items.Add(element); // add available pins for selection
               uart_ext_clck.Items.Add(element);// add available pins for selection
            }
            
            foreach (var element in (dynamic)analog_pins)
            {
                analog_pins_selc.Items.Add(element); // add available analog  pins for selection
            }
        
       
        }

        private void portconfig()
        {

            #region portselction
            switch (selc )
         {
             case "1":
                 port = 1;
                 bit= 0;
                 if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                  }
                 break;
             case "2":
                 port = 1;
                 bit = 1;
                 if (analog_pins_selc.Text == selc)
                 {
                     port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                     portmapping();
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                     port_init_statements.Add("\r\n P" + port+"DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     { 
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                     }
                 }
                 if (uart_pins_selc.Text == selc)
                 {
                     port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                     if (inorout == "Uart_Rx")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                         portmapping();
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                         
                     }
                 }
                 if (uart_ext_clck.Text == selc)
                 {
                     port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     portmapping();
                 }
                 break;
             case "3":
                 port = 1;
                 bit = 2;
                if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "4":
                 port = 1;
                 bit = 3;
                 if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "5":
                 port = 1;
                 bit = 4;
                 if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "6":
                 port = 1;
                 bit = 5;
                 if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "11":
                 port = 1;
                 bit = 6;
                 if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "12":
                 port = 1;
                 bit = 7;
                  if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "13":
                 port =2;
                 bit = 0;
                  if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "14":
                 port = 2;
                 bit = 1;
                if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "15":
                 port = 2;
                 bit = 2;
              if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             case "16":
                 port = 2;
                 bit = 3;
                 if(analog_pins_selc.Text == selc)
                 {
                 port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                 portmapping();
                     break;
                 }
                 if (gpio_pins_selc.Text == selc)
                 {
                     if (inorout == "IN")
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                     }
                     else
                     {
                         port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                    
                     }
                 }
                  if (uart_pins_selc.Text == selc)
                     {
                         port_init_statements.Add("\r\nP" + port + "SEL |= BIT" + bit + ";");
                         if (inorout == "Uart_Rx")
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                             portmapping();
                         }
                         else
                         {
                             port_init_statements.Add("\r\n P" + port + "DIR |= BIT" + bit + ";");
                             portmapping();
                         }                           
                     }
                  if (uart_ext_clck.Text == selc)
                  {
                      port_init_statements.Add("\r\n P" + port + "DIR &= ~ BIT" + bit + ";");
                      portmapping();
                  }
                 break;
             default:
                 break;
         }
            #endregion port selction
        }
        public void generate_Click(object sender, EventArgs e)
        {
            
            textBox1.Text = "#include <msp430f5152.h>";
            textBox1.Text += "\r\n #include<main.h>";
            textBox1.Text += "\r\nint main(void)";
            textBox1.Text += "\r\n {";
            textBox1.Text += "\r\n WDTCTL = WDTPW + WDTHOLD;                 // Stop WDT";
           foreach(string element in port_init_statements)
           {
               textBox1.Text += element;
           }
           //textBox1.Text += "\r\n P3OUT |= BIT0+BIT1;";
           #region portmapping
           while (port_mapping_statements.Count > 0)
           {
           textBox1.Text += "\r\n PMAPPWD = 0x02D52;      // Enable Write-access to modify port mapping registers";
           textBox1.Text += "\r\n  PMAPCTL = PMAPRECFG;    // Allow reconfiguration during runtime";
           foreach (string element in port_mapping_statements)
           {
               textBox1.Text += element;
           }
           //textBox1.Text += "\r\n P3MAP0 = PM_UCA0TXD;";
           //textBox1.Text += "\r\n P3MAP1 = PM_UCA0RXD;";
           textBox1.Text += "\r\n  PMAPPWD = 0;            // Disable Write-Access to modify port mapping registers by writing incorrect key";
           break;
           }
           #endregion
           #region analog part
           while (vref.SelectedItem != null)
           {
               textBox1.Text += "\r\n // By default, REFMSTR=1 => REFCTL is used to configure the internal reference";
               textBox1.Text += " \r\n while(REFCTL0 & REFGENBUSY);              // If ref generator busy, WAIT ";
               textBox1.Text += internref + "                 // selcted internal reference is ON";
               break;
           }
           while (analog_pins_selc.SelectedItems.Count > 0)
           {
               textBox1.Text += "\r\n // configure adc";
               textBox1.Text += "\r\n   ADC10CTL0 =  ADC10ON;                        // ADC10ON";
               textBox1.Text += "\r\n    ADC10CTL2 |= ADC10RES;                    // 10-bit conversion results ";
               textBox1.Text += "\r\n    ADC10IE |= ADC10IE0;                      // Enable ADC conv complete interrupt";
               textBox1.Text += vref_statements[0];
               textBox1.Text += "\r\n ADC10CTL0 |= ADC10ENC + ADC10SC;         // Sampling and conversion start";
               break;
           }
           #endregion
           #region uart 
           while (uart_pins_selc.SelectedItems.Count > 0)
           {
               textBox1.Text += "//configure uart";
               textBox1.Text += " UCA0CTL1 |= UCSWRST;         // **Put state machine in reset** ";
               textBox1.Text += " UCA0CTL1 |= UCSSEL_1;                     // CLK = ACLK";
               textBox1.Text += "  UCA0CTL1 &= ~UCSWRST;                     // **Initialize USCI state machine**";
               break;
           }
           #endregion uart

           textBox1.Text += " \r\n }";
           #region analog pragmavector
           while (analog_pins_selc.SelectedItems.Count > 0)
           {
               textBox1.Text += "\r\n // ADC10 interrupt service routine";
               textBox1.Text += "\r\n #if defined(__TI_COMPILER_VERSION__) || defined(__IAR_SYSTEMS_ICC__)";
               textBox1.Text += "\r\n #pragma vector=ADC10_VECTOR";
               textBox1.Text += "\r\n __interrupt void ADC10_ISR(void)";
               textBox1.Text += "\r\n #elif defined(__GNUC__)";
               textBox1.Text += "\r\n void __attribute__ ((interrupt(ADC10_VECTOR))) ADC10_ISR (void)";
               textBox1.Text += "\r\n #else";
               textBox1.Text += "\r\n #error Compiler not supported!";
               textBox1.Text += " \r\n #endif";
               textBox1.Text += "\r\n {";
               textBox1.Text += "\r\n   switch(__even_in_range(ADC10IV,12))";
               textBox1.Text += "\r\n {";
               textBox1.Text += "\r\n case  0: break;                          // No interrupt";
               textBox1.Text += "\r\n case  2: break;                          // conversion result overflow";
               textBox1.Text += "\r\n case  4: break;                          // conversion time overflow";
               textBox1.Text += "\r\n case  6: break;                          // ADC10HI";
               textBox1.Text += "\r\n case  8: break;                          // ADC10LO";
               textBox1.Text += "\r\n case 10: break;                          // ADC10IN";
               textBox1.Text += "\r\n case 12: ADC10MEM0;";
               textBox1.Text += "\r\n          __bic_SR_register_on_exit(CPUOFF); ";
               textBox1.Text += "\r\n          break;                          // Clear CPUOFF bit from 0(SR) ";
               textBox1.Text += "\r\n  default: break; ";
               textBox1.Text += "\r\n }";
               textBox1.Text += "\r\n }";
               break;

           }
           #endregion
           File.WriteAllText("D:\\Users\\i00109852\\Documents\\IAR Embedded Workbench\\auto code\\main.cpp", textBox1.Text);
        }
        
        public void portmapping()
        {
            if (analog_pins_selc.Text == selc)
            port_mapping_statements.Add("\r\nP" + port + "MAP" + bit + "|=PM_ANALOG; "); 
            if(inorout == "Uart_Tx")
            port_mapping_statements.Add("\r\nP" + port + "MAP" + bit + "|=PM_UCA0TXD; ");
            if (inorout == "Uart_Rx")
             port_mapping_statements.Add("\r\nP" + port + "MAP" + bit + "|=PM_UCA0RXD; "); 
            if(uart_ext_clck.Text == selc)
                port_mapping_statements.Add("\r\nP" + port + "MAP" + bit + "|=PM_UCA0CLK; "); 
              
        }
        private void analog_pins_selc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            selc = analog_pins_selc.Text;
            portconfig();
            gpio_pins_selc.Items.Remove(analog_pins_selc.SelectedItem); // remove selceted pins for further selection
            uart_pins_selc.Items.Remove(analog_pins_selc.SelectedItem); // remove selceted pins for further selection
            uart_ext_clck.Items.Remove(analog_pins_selc.SelectedItem); // remove selceted pins for further selection
        }
        private void uart_pins_selc_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            GPIO.Controls.Add(uart_tx);
            GPIO.Controls.Add(uart_rx);
            uart_tx.Click +=new EventHandler(uart_tx_Click);
            uart_rx.Click +=new EventHandler(uart_rx_Click);
            GPIO.ShowDialog();
            selc = uart_pins_selc.Text;
            portconfig();
            gpio_pins_selc.Items.Remove(uart_pins_selc.SelectedItem); // remove selceted pins for further selection
            uart_ext_clck.Items.Remove(uart_pins_selc.SelectedItem); // remove selceted pins for further selection
            analog_pins_selc.Items.Remove(uart_pins_selc.SelectedItem); // remove selceted pins for further selection
        }
        private void gpio_pins_selc_ItemCheck(object sender, ItemCheckEventArgs e)
        {

            GPIO.Controls.Add(GPIO_Input);
            GPIO.Controls.Add(GPIO_output);
            GPIO_Input.Click += new EventHandler(GPIO_Input_Click);
            GPIO_output.Click += new EventHandler(GPIO_output_Click);
            GPIO.ShowDialog();
            this.Show();
         
            selc = gpio_pins_selc.Text;
            portconfig();
            uart_ext_clck.Items.Remove(gpio_pins_selc.SelectedItem); // remove selceted pins for further selection
            uart_pins_selc.Items.Remove(gpio_pins_selc.SelectedItem); // remove selceted pins for further selection
            analog_pins_selc.Items.Remove(gpio_pins_selc.SelectedItem); // remove selceted pins for further selection
        }
        private void GPIO_Input_Click(Object sender, EventArgs e) 
        {
            inorout = GPIO_Input.Text;
            this.GPIO.Hide();
        }
        private void GPIO_output_Click(Object sender, EventArgs e)
        {
            inorout = GPIO_output.Text;
            this.GPIO.Hide();
        }
        private void uart_tx_Click(Object sender, EventArgs e)
        {
            inorout = uart_tx.Text;
            this.GPIO.Hide();
        }
        private void uart_rx_Click(Object sender, EventArgs e)
        {
            inorout = uart_rx.Text;
            this.GPIO.Hide();
        }
        private void analog_volt_ref_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (analog_volt_ref.SelectedIndex)
            {
                case 0:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_0;  //  vref selection");
                   
                    break;
                case 1:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_1;  //  vref selection");
                    vref.Visible = true;
                    break;
                case 2:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_2;  //  vref selection");
                    break;
                case 3:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_3;  //  vref selection");
                    analog_pins_selc.Items.Remove(34);
                    break;
                case 4:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_4;  //  vref selection");
                    analog_pins_selc.Items.Remove(35);
                    break;
                case 5:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_5;  //  vref selection");
                    analog_pins_selc.Items.Remove(35);
                    vref.Visible = true;
                    break;
                case 6:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_6;  //  vref selection");
                    analog_pins_selc.Items.Remove(35);
                    break;
                case 7:
                    vref_statements.Add("\r\n ADC10MCTL0 |=  ADC10SREF_7;  //  vref selection");
                    analog_pins_selc.Items.Remove(34);
                    analog_pins_selc.Items.Remove(35);
                    break;
               default:
                    break;
               
            }
        }

       private void vref_SelectedIndexChanged(object sender, EventArgs e)
        {
            internref = "\r\n REFCTL0 |= REFON + REFVSEL_"+vref.SelectedIndex+";";
        }

      

       private void uart_ext_clck_ItemCheck(object sender, ItemCheckEventArgs e)
       {
           selc = uart_ext_clck.Text;
           portconfig();
           uart_pins_selc.Items.Remove(uart_ext_clck.SelectedItem);
           gpio_pins_selc.Items.Remove(uart_ext_clck.SelectedItem);
           analog_pins_selc.Items.Remove(uart_ext_clck.SelectedItem);  
       }

       private void ext_clck_CheckedChanged(object sender, EventArgs e)
       {
           uart_ext_clck.Visible = true;
       }

       

        
      

      

        

        
    }
}
