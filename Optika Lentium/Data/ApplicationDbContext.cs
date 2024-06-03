using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Optika_Lentium.Models;

namespace Optika_Lentium.Data
{
	public class ApplicationDbContext : IdentityDbContext<Korisnik>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Lokacija> Lokacija { get; set; }
		public DbSet<LokacijaKorisnik> LokacijaKorisnik { get; set; }
		public DbSet<NacinPlacanja> NacinPlacanja { get; set; }
		public DbSet<Narucivanje> Narucivanje { get; set; }
		public DbSet<Placanje> Placanje { get; set; }
		public DbSet<Popust> Popust { get; set; }
		public DbSet<PregledKorisnik> PregledKorisnik { get; set; }
		public DbSet<Proizvod> Proizvod { get; set; }
		public DbSet<ProizvodKorisnik> ProizvodKorisnik { get; set; }
		public DbSet<ValidacijaProizvoda> ValidacijaProizvoda { get; set; }
		public DbSet<ZakazivanjePregleda> ZakazivanjePregleda { get; set; }

		public DbSet<NoviKorisnik> NoviKorisnik { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Lokacija>().ToTable("Lokacija");
			modelBuilder.Entity<LokacijaKorisnik>().ToTable("LokacijaKorisnik");
			modelBuilder.Entity<NacinPlacanja>().ToTable("NacinPlacanja");
			modelBuilder.Entity<Narucivanje>().ToTable("Narucivanje");
			modelBuilder.Entity<Placanje>().ToTable("Placanje");
			modelBuilder.Entity<Popust>().ToTable("Popust");
			modelBuilder.Entity<PregledKorisnik>().ToTable("PregledKorisnik");
			modelBuilder.Entity<Proizvod>().ToTable("Proizvod");
			modelBuilder.Entity<ProizvodKorisnik>().ToTable("ProizvodKorisnik");
			modelBuilder.Entity<ValidacijaProizvoda>().ToTable("ValidacijaProizvoda");
			modelBuilder.Entity<ZakazivanjePregleda>().ToTable("ZakazivanjePregleda");
			modelBuilder.Entity<NoviKorisnik>().ToTable("NoviKorisnik");
			modelBuilder.Entity<Korisnik>(b =>
			{
				b.Property(u => u.korisnikId);
				b.Property(u => u.kupacId);
				b.Property(u => u.radnikId);
				b.Property(u => u.vlasnikId);
				b.Property(u => u.ime);
				b.Property(u => u.prezime);
				b.Property(u => u.sifra);
			});
			base.OnModelCreating(modelBuilder);
		}
	}
}
