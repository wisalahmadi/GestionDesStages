using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionDesStages.Shared.Policies
{
    public static class Policies
    {
        public const string EstEtudiant = "EstEtudiant";
        public const string EstEntreprise = "EstEntreprise";

        public static AuthorizationPolicy EstEtudiantPolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                //.RequireClaim("Statut", "Milieu")
                .RequireRole("Etudiant")
                .Build();
        }
        
            public static AuthorizationPolicy EstEntreprisePolicy()
        {
            return new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                //.RequireClaim("Statut", "Milieu")
                .RequireRole("Entreprise")
                .Build();
        }
    }
}