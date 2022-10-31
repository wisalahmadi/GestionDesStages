using GestionDesStages.Client.Interfaces;
using GestionDesStages.Server.Data;
using GestionDesStages.Server.Interface;
using GestionDesStages.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionDesStages.Server.Repository
{
    public class EntrepriseRepository :IEntrepriseRepository
    {
        private readonly ApplicationDbContext _appDbContext;
        private readonly ILogger<EntrepriseRepository> _logger;

        public EntrepriseRepository(ApplicationDbContext appDbContext, ILogger<EntrepriseRepository> logger)
        {
            _appDbContext = appDbContext;
            _logger = logger;
        }
        public Entreprise GetEntrepriseById(string Id)
        {
            // Obtenir la fiche de l'étudiant
            return _appDbContext.Entreprise.AsNoTracking().FirstOrDefault(c => c.Id == Id);
        }

        public Entreprise AddEntreprise(Entreprise entreprise)
        {
            try
            {
                var addedEntity = _appDbContext.Entreprise.Add(entreprise);
                _appDbContext.SaveChanges();
                return addedEntity.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erreur dans la création d'un enregistrement {ex}");
                return null;
            }
        }

        public Entreprise UpdateEntreprise(Entreprise entreprise)
        {
            // Rechercher le stage afin d'indiquer au contexte le stage à mettre à jour
            var foundEntreprise = _appDbContext.Entreprise.FirstOrDefault(e => e.Id == entreprise.Id);
            if (foundEntreprise != null)
            {
                foundEntreprise.Nom = entreprise.Nom;
                foundEntreprise.NomResponsable = entreprise.NomResponsable;
                foundEntreprise.PrenomResponsable = entreprise.PrenomResponsable;
                foundEntreprise.PosteTelephonique= entreprise.PosteTelephonique;
                foundEntreprise.TelephoneCellulaire = entreprise.TelephoneCellulaire;
                _appDbContext.SaveChanges();
            }
            return foundEntreprise;
        }
    }
}
