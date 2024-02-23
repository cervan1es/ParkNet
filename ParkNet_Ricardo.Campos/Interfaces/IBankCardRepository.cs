﻿using ParkNet_Ricardo.Campos.Data.Entities;

namespace ParkNet_Ricardo.Campos.Interfaces
{
    public interface IBankCardRepository
    {
        List<BankCard> GetAllCustomerBankCards(Guid Customer);
    }
}
