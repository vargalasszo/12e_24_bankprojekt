using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankProject;//TestBankproject References add new reference

//új teszteset - futtatás (sikertelennek kell lennie) - implementálás (megírjuk a kódot, kezdetben az ujszamla fv üres) 
namespace TestBankprojekt
{
	internal class BankTeszt
	{
		[Test]
		public void UjSzamla_HelyesAdatokkal_Egyenleg0()
		{
			Bank bank = new Bank();
			bank.UjSzamla("Gipsz Jakab", "1234");

			//if (bank.Egyenleg("1234") == 0)
			//{
			//Assert.Pass();
			//        }
			Assert.That(bank.Egyenleg("1234"), Is.Zero);
		}


		[Test]
		public void UjSzamla_NullNevvel_ArgumenNullExceptiontDob()
		{
			Bank bank = new Bank();
			Assert.Throws<ArgumentNullException>(() => bank.UjSzamla(null,"1234"));
		}

		[Test]
		public void UjSzamla_UresNevvel_ArgumenExceptiontDob()
		{
			Bank bank = new Bank();
			Assert.Throws<ArgumentException>(() => bank.UjSzamla("", "1234"));
		}

		[Test]
		public void UjSzamla_NullSzamlaszammal_ArgumenNullExceptiontDob()
		{
			Bank bank = new Bank();
			Assert.Throws<ArgumentNullException>(() => bank.UjSzamla("Gipsz Jakab", null));
		}

		[Test]
		public void UjSzamla_UresSzamlaszammal_ArgumenExceptiontDob()
		{
			Bank bank = new Bank();
			Assert.Throws<ArgumentException>(() => bank.UjSzamla("GipszJakab", ""));
		}

		[Test]
		public void UjSzamla_LetezoSzamlaszammal_ArgumenExceptiontDob()
		{
			Bank bank = new Bank();
			bank.UjSzamla("Gipsz Jakab", "1234");
			Assert.Throws<ArgumentException>(() => bank.UjSzamla("Teszt Elek", "1234"));
		}

		[Test]
		public void UjSzamla_LetezoNevvel_NemDobKivetelt()
		{
			Bank bank = new Bank();
			bank.UjSzamla("Gipsz Jakab", "1234");
			Assert.DoesNotThrow(() => bank.UjSzamla("Gipsz Jakab", "4321"));
		}

	}
}
