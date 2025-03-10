using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace api_acesso_ia.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Status { get; set; }
        
        [Column("foto_perfil")]
        [JsonIgnore]
        public string? FotoPerfil { get; set; }
        public string? FotoPerfilBase64Resumido
        => string.IsNullOrEmpty(FotoPerfil) ||
            FotoPerfil.Length <=30 ? FotoPerfil :
            FotoPerfil.Substring(0, 30) + "...";
    }
}
