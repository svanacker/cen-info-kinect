﻿using System;
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

namespace UartWPFTest
{
    using System.ComponentModel;
    using System.IO.Ports;
    using System.Threading;
    using NUnit.Framework;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort currentPort;

        private const int COM_INPUT_COUNT = 10;

        private InputHistory[] inputHistories = new InputHistory[COM_INPUT_COUNT];

        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < COM_INPUT_COUNT; i++)
            {
                inputHistories[i] = new InputHistory();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentPort == null)
            {
                return;
            }
            currentPort.Close();
        }

        private TextBox GetLinkedTextBox(Button sendButton)
        {
            if (SendButton1 == sendButton) { return SendTextBox1; }
            if (SendButton2 == sendButton) { return SendTextBox2; }
            if (SendButton3 == sendButton) { return SendTextBox3; }
            if (SendButton4 == sendButton) { return SendTextBox4; }
            if (SendButton5 == sendButton) { return SendTextBox5; }
            if (SendButton6 == sendButton) { return SendTextBox6; }
            if (SendButton7 == sendButton) { return SendTextBox7; }
            if (SendButton8 == sendButton) { return SendTextBox8; }
            
            return null;
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = sender as Button;
            if (senderButton == null)
            {
                return;
            }
            TextBox textBox = GetLinkedTextBox(senderButton);
            string text = textBox.Text;
            SendText(text);
            InputHistory inputHistory = GetInputHistory(textBox);
            inputHistory.AddEntry(text);
        }

        private void SendText(string text)
        {
            if (currentPort == null)
            {
                return;
            }
            currentPort.WriteLine(text);
            // we add some line return so that we can read easily the return of the remote board
            ContentTextBox.Text += "\n";
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ContentTextBox.Clear();
        }

        private void LoadPortNames()
        {
            string[] portNames = SerialPort.GetPortNames();
            COMComboBox.Items.Clear();
            foreach (string portName in portNames)
            {
                COMComboBox.Items.Add(portName);
            }
        }

        private void LoadListButton_Click(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }

        private void COMComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object selectedItem = COMComboBox.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            if (currentPort != null && currentPort.IsOpen)
            {
                currentPort.Close();
                currentPort.DataReceived -= UartReceive;
            }
            currentPort = new SerialPort(selectedItem.ToString(), 115200, Parity.None, 8, StopBits.One);
            currentPort.Open();
            currentPort.DataReceived += UartReceive;
        }

        private void UartReceive(object sender, SerialDataReceivedEventArgs e)
        {
            if (currentPort == null)
            {
                return;
            }
            int bytesToRead = currentPort.BytesToRead;
            if (bytesToRead == 0)
            {
                return;
            }

            byte[] buffer = new byte[bytesToRead];
            currentPort.Read(buffer, 0, bytesToRead);
            ContentTextBox.Dispatcher.BeginInvoke(new Action(delegate()
            {
                string newText = Encoding.ASCII.GetString(buffer, 0, bytesToRead);
                ContentTextBox.Text += newText;
                // ContentTextBox.Text += "\n";
                ContentTextBox.ScrollToEnd();
                ContentScrollViewer.ScrollToVerticalOffset(ContentScrollViewer.ScrollableHeight);
                ContentScrollViewer.UpdateLayout();
            }));
        }

        private InputHistory GetInputHistory(TextBox textBox)
        {
            if (textBox.Equals(SendTextBox1))
            {
                return inputHistories[0]; 
            }
            else if (textBox.Equals(SendTextBox2))
            {
                return inputHistories[1];
            }
            else if (textBox.Equals(SendTextBox3))
            {
                return inputHistories[2];
            }
            else if (textBox.Equals(SendTextBox4))
            {
                return inputHistories[3];
            }
            else if (textBox.Equals(SendTextBox5))
            {
                return inputHistories[4];
            }
            else if (textBox.Equals(SendTextBox6))
            {
                return inputHistories[5];
            }
            else if (textBox.Equals(SendTextBox7))
            {
                return inputHistories[6];
            }
            else if (textBox.Equals(SendTextBox8))
            {
                return inputHistories[7];
            }
            return null;
        }

        private void SendTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            InputHistory inputHistory = GetInputHistory(textBox);
            string text = textBox.Text;
            char key = (char)KeyInterop.VirtualKeyFromKey(e.Key);
            if (e.Key == Key.Return)
            {
                SendText(text);
                inputHistory.AddEntry(text);
            }
            else if (e.Key == Key.Down)
            {
                InputHistoryItem item = inputHistory.FindPreviousHistoryItem();
                if (item != null)
                {
                    textBox.Text = item.Text;
                }
            }
            else if (e.Key == Key.Up)
            {
                InputHistoryItem item = inputHistory.FindNextHistoryItem();
                if (item != null)
                {
                    textBox.Text = item.Text;
                }
            }
            else if (e.Key >= Key.A && e.Key <= Key.Divide)
            {
                string completion = inputHistory.GetMostCloseTo(text);
                if (completion != null)
                {
                    e.Handled = true;
                    textBox.Text = completion;
                    textBox.SelectionStart = text.Length;
                    textBox.SelectionLength = completion.Length - textBox.SelectionLength;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPortNames();
        }
    }
}
