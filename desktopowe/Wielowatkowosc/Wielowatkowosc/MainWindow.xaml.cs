﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wielowatkowosc
{
    public partial class MainWindow : Window
    {
        private CancellationTokenSource _stopwatch1Cts;
        private CancellationTokenSource _stopwatch2Cts;
        private TimeSpan _stopwatch1Time = TimeSpan.Zero;
        private TimeSpan _stopwatch2Time = TimeSpan.Zero;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void StartStopwatch1_Click(object sender, RoutedEventArgs e)
        {
            if (_stopwatch1Cts == null || _stopwatch1Cts.IsCancellationRequested)
            {
                _stopwatch1Cts = new CancellationTokenSource();
                await RunStopwatch1(_stopwatch1Cts.Token);
            }
        }

        private void PauseStopwatch1_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch1Cts?.Cancel();
        }

        private void ResetStopwatch1_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch1Cts?.Cancel();
            _stopwatch1Time = TimeSpan.Zero;
            Stopwatch1Display.Text = "00:00:00";
        }

        private async Task RunStopwatch1(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    _stopwatch1Time = _stopwatch1Time.Add(TimeSpan.FromSeconds(1));
                    await Dispatcher.InvokeAsync(() =>
                    {
                        Stopwatch1Display.Text = _stopwatch1Time.ToString(@"hh\:mm\:ss");
                    });
                    await Task.Delay(1000, token);
                }
            }
            catch (TaskCanceledException) { }
        }

        private async void StartStopwatch2_Click(object sender, RoutedEventArgs e)
        {
            if (_stopwatch2Cts == null || _stopwatch2Cts.IsCancellationRequested)
            {
                _stopwatch2Cts = new CancellationTokenSource();
                await RunStopwatch2(_stopwatch2Cts.Token);
            }
        }

        private void PauseStopwatch2_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch2Cts?.Cancel();
        }

        private void ResetStopwatch2_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch2Cts?.Cancel();
            _stopwatch2Time = TimeSpan.Zero;
            Stopwatch2Display.Text = "00:00:00";
        }

        private async Task RunStopwatch2(CancellationToken token)
        {
            try
            {
                while (!token.IsCancellationRequested)
                {
                    _stopwatch2Time = _stopwatch2Time.Add(TimeSpan.FromSeconds(1));
                    await Dispatcher.InvokeAsync(() =>
                    {
                        Stopwatch2Display.Text = _stopwatch2Time.ToString(@"hh\:mm\:ss");
                    });
                    await Task.Delay(1000, token);
                }
            }
            catch (TaskCanceledException) { }
        }
    }
}