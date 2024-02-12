﻿namespace ParkNet_Ricardo.Campos.Entities
{
    public class Park
    {
        public Guid ID { get; private set; }
        public string Name { get; set; }

        public Park() 
        {
            ID = Guid.NewGuid();
        }
    }
}