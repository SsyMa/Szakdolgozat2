using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Evolutions
{
    public abstract class Evolution : NetworkBehaviour
    {
        public int cost;
        public int costIncrease;
        protected float brokeTimer;
        public float valueIncrease;
        public string description;
        public int numberOfLevels;
        public int currentLevel;
        public List<Evolution> prequisites;

        protected EvolutionManager em;
        protected CurrencyManager cm;

        public abstract void OnClick();

        override public string ToString()
        {
            return $"{cost} DNA\n" +
                   $"{description}\n" +
                   $"{currentLevel}/{numberOfLevels}";
        }
    }

}
