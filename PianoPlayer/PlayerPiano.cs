using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace PianoPlayer
{
    /*
        * @Author: Rahul Anton and Victor Ouy
        * @Date: 18/02/2020
        * 
        * Class to represent a piano player that produces audio reading from a txt file
        */
    class PlayerPiano
    {
        /*
        * @Author: Rahul Anton and Victor Ouy
        * @param   string[] args
        * 
        * 
        * Main method that will read a txt file to store a string and to play audio
        */
        static void Main(string[] args)
        {
            Audio player = new Audio();
            string[] text = File.ReadAllLines("chopsticks.txt");
            string keys = text[0];
            int samplingrate = 44100;

            Piano piano = new Piano(keys, samplingrate);

            for (int i = 1; i < text.Length; i++)
            {
                string notes = text[i];
                for (int j = 0; j < notes.Length; j++)
                {
                    char key = notes[j];
                    piano.StrikeKey(key);
                }
                for (int k = 0; k <= (samplingrate * 3); k++)
                {
                    player.Play(piano.Play());
                }

                Thread.Sleep(400);
            }
        }
    }
}
