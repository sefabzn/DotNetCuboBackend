﻿using Core.Entities;

namespace Entities.Concrete;

public class MakineKesitHizTablosu : IEntity
{
    public int Id { get; set; }
    public double KesitCapi { get; set; }
    public int MakineId { get; set; }
    public int Hiz { get; set; }
}

