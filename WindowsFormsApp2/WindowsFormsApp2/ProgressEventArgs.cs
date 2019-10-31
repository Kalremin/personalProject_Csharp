using System;


namespace YouMuEx_convert
{
    class ProgressEventArgs:EventArgs
    {
        public bool Cancel { get; set; }
        public double ProgressPercentage { get; private set; }

        public ProgressEventArgs(double progressPercentage)
        {
            this.ProgressPercentage = progressPercentage;
        }
    }
}
