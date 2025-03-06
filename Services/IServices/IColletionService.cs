﻿using BibliotecaSánchezLobatoGael83.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BibliotecaSánchezLobatoGael83.Services
{
    public interface ICollectionService
    {
        Task<IEnumerable<Collection>> GetAllCollectionsAsync();
        Task<Collection> GetCollectionByIdAsync(int id);
        Task AddCollectionAsync(Collection collection);
        Task UpdateCollectionAsync(Collection collection);
        Task DeleteCollectionAsync(int id);
        Task<int> CountCollectionsAsync();
    }
}
