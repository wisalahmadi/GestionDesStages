﻿using GestionDesStages.Server.Data;
using GestionDesStages.Server.Interface;
using GestionDesStages.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDesStages.Server.Repository
{
    public class EtudiantRepository : IEtudiantRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<EtudiantRepository> _logger;

        public EtudiantRepository(ApplicationDbContext appDbContext, ILogger<EtudiantRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }


        public Etudiant GetEtudiantById(string Id)
        {
            // Obtenir la fiche de l'étudiant
            return _appDbContext.Etudiant.AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        public Etudiant AddEtudiant(Etudiant etudiant)
        {
            try
            {
                var addedEntity = _appDbContext.Etudiant.Add(etudiant);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }
        }

        public Etudiant UpdateEtudiant(Etudiant etudiant)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundEtudiant = _appDbContext.Etudiant.FirstOrDefault(e => e.Id == etudiant.Id);
            if (foundEtudiant != null)
            {
                foundEtudiant.Prenom = etudiant.Prenom;
                foundEtudiant.Nom = etudiant.Nom;
                foundEtudiant.TelephoneCellulaire = etudiant.TelephoneCellulaire;
                foundEtudiant.adresse = etudiant.adresse;
                _appDbContext.SaveChanges();
            }
            return foundEtudiant;
        }
    }
}
