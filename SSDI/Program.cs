class Program
{
	static void Main(string[] args)
	{
		List<Talaba> talabalar = new List<Talaba>();
		List<Oqituvchi> oqituvchilar = new List<Oqituvchi>();

		//  talabalar uchun ma'lumotlarni yaratish 
		Random random = new Random();
		for (int i = 1; i <= 10; i++)
		{
			Talaba talaba = new Talaba
			{
				Id = i,
				Ism = GenerateRandomName(),
				Familiya = GenerateRandomLastName(),
				Telefon = GenerateRandomPhoneNumber(),
				Email = GenerateRandomEmail(),
				TugilganSana = GenerateRandomBirthDate(),
				StudentRegNumber = GenerateRandomRegNumber()
			};
			talabalar.Add(talaba);
		}

		//  oqituvchilar uchun ma'lumotlarni yaratish
		for (int i = 1; i <= 5; i++)
		{
			Oqituvchi oqituvchi = new Oqituvchi
			{
				Id = i,
				Ism = GenerateRandomName(),
				Familiya = GenerateRandomLastName(),
				Telefon = GenerateRandomPhoneNumber(),
				Email = GenerateRandomEmail(),
				TugilganSana = GenerateRandomBirthDate()
			};
			oqituvchilar.Add(oqituvchi);
		}

		// Har bir talaba uchun random mavzularni yarating  
		foreach (Talaba talaba in talabalar)
		{
			int numSubjects = random.Next(1, 5); // Talab uchun mavzular sonini random tanlang
			for (int i = 1; i <= numSubjects; i++)
			{
				Subject subject = new Subject
				{
					Id = i,
					Ism = GenerateRandomSubject()
				};
				talaba.Subjects.Add(subject);
			}
		}

		// 1) 20 yoshgacha bo'lgan barcha talabalar ma'lumotlarini ko'rsatish

		Console.WriteLine("1) 20 yoshgacha bo'lgan barcha talabalar ma'lumotlari:");

		foreach (Talaba talaba in talabalar)
		{
			if (CalculateAge(talaba.TugilganSana) <= 20)
			{
				Console.WriteLine($"{talaba.Ism} {talaba.Familiya} - {talaba.Telefon}");
			}
		}

		// 2) 12-avgustdan 18-sentyabrgacha tugʻilgan barcha oʻquvchilarning maʼlumotlarini koʻrsatish

		DateTime startDate = new DateTime(DateTime.Now.Year, 8, 12);
		DateTime endDate = new DateTime(DateTime.Now.Year, 9, 18);

		Console.WriteLine("\n2) 12-avgustdan 18-sentyabrgacha tugʻilgan barcha oʻquvchilarning maʼlumotlari:");

		foreach (Talaba talaba in talabalar)
		{
			if (talaba.TugilganSana >= startDate && talaba.TugilganSana <= endDate)
			{
				Console.WriteLine($"{talaba.Ism} {talaba.Familiya} - {talaba.Telefon}");
			}
		}

		// 3) 55 yoshdan oshgan barcha oʻqituvchilarning maʼlumotlarini koʻrsatish
		Console.WriteLine("\n3) 55 yoshdan oshgan barcha oʻqituvchilarning maʼlumotlari:");

		foreach (Oqituvchi oqituvchi in oqituvchilar)
		{
			if (CalculateAge(oqituvchi.TugilganSana) > 55)
			{
				Console.WriteLine($"{oqituvchi.Ism} {oqituvchi.Familiya} - {oqituvchi.Telefon}");
			}
		}

		// 4) Beeline mobil raqamidan foydalangan holda barcha talabalar va o'qituvchilarning ma'lumotlarini ko'rsatish (kod 90 yoki 91)

		string beelineCode = "90";
		Console.WriteLine("\n4) Beeline mobil raqamidan foydalangan holda barcha talabalar va o'qituvchilarning ma'lumotlari:");

		foreach (Talaba talaba in talabalar)
		{
			if (talaba.Telefon.StartsWith("+998" + beelineCode))
			{
				Console.WriteLine($"{talaba.Ism} {talaba.Familiya} - {talaba.Telefon}");
			}
		}

		foreach (Oqituvchi oqituvchi in oqituvchilar)
		{
			if (oqituvchi.Telefon.StartsWith("+998" + beelineCode))
			{
				Console.WriteLine($"{oqituvchi.Ism} {oqituvchi.Familiya}" +
					$" - {oqituvchi.Telefon}");
			}
		}

		// 5) Ismi yoki familiyasida kiritilgan ibora bo'lgan barcha talabalarning ma'lumotlarini ko'rsatish

		string searchKeyword = "John"; //Qidiruv kalit so'ziga misol

		Console.WriteLine($"\n5) Ismi yoki familiyasida \"{searchKeyword}\" " +
			$"ibora bo'lgan barcha talabalar ma'lumotlari:");

		foreach (Talaba talaba in talabalar)
		{
			if (talaba.Ism.Contains(searchKeyword) || talaba.Familiya.Contains(searchKeyword))
			{
				Console.WriteLine($"{talaba.Ism} {talaba.Familiya} - {talaba.Telefon}");
			}
		}

		// 6) Tanlangan talaba eng yuqori ball toʻplagan fanni koʻrsatish

		Talaba selectedTalaba = talabalar[random.Next(talabalar.Count)]; // Tasodifiy talabani tanlang

		Console.WriteLine($"\n6) {selectedTalaba.Ism} {selectedTalaba.Familiya}" +
			$" eng yuqori ball toʻplagan fan:");

		int maxMark = selectedTalaba.Subjects.Max(s => s.Id);
		Subject maxMarkSubject = selectedTalaba.Subjects.Find(s => s.Id == maxMark);
		Console.WriteLine($"{maxMarkSubject.Ism} - {maxMark}");

		// 7) Tanlangan oʻqituvchi tomonidan oʻqitiladigan va 80 balldan yuqori ball olgan 10 nafar talaba boʻlgan fanni koʻrsatish

		Oqituvchi selectedOqituvchi = oqituvchilar[random.Next(oqituvchilar.Count)]; // Tafodifiy oqituvchi talang 

		Console.WriteLine($"\n7) {selectedOqituvchi.Ism} {selectedOqituvchi.Familiya} " +
			$"tomonidan oʻqitiladigan va 80 balldan yuqori ball olgan 10 nafar talaba boʻlgan fanlar:");

		List<Talaba> highMarkTalabalar = talabalar.FindAll(t =>
		t.Subjects.Exists(s => s.Ism == selectedOqituvchi.Ism) &&
		t.Subjects.Exists(s => s.Id > 80));

		foreach (Talaba talaba in highMarkTalabalar)
		{
			Console.WriteLine($"{talaba.Ism} {talaba.Familiya}");
		}

		// 8) Talabalarning eng yuqori balli 97 dan yuqori bo'lgan fanlardan dars beradigan o'qituvchilarni ko'rsatish

		Console.WriteLine("\n8) Talabalarning eng yuqori balli 97 dan yuqori bo'lgan fanlardan dars beradigan o'qituvchilar:");

		foreach (Oqituvchi oqituvchi in oqituvchilar)
		{
			List<Talaba> highMarkTalabalarForOqituvchi = talabalar.FindAll(t =>
			t.Subjects.Exists(s => s.Ism == oqituvchi.Ism) &&
			t.Subjects.Exists(s => s.Id > 97));

			if (highMarkTalabalarForOqituvchi.Count > 0)
			{
				Console.WriteLine($"{oqituvchi.Ism} {oqituvchi.Familiya} " +
					$"- {oqituvchi.Telefon}");
			}
		}

		// 9) Talabaning o'rtacha bahosi eng yuqori bo'lgan fanni ko'rsatish
		Console.WriteLine("\n9) Talabaning o'rtacha bahosi eng yuqori bo'lgan fan:");
		double maxAverageMark = talabalar.Max(t => t.Subjects.Average(s => s.Id));

		Talaba talabaWithMaxAverageMark = talabalar.Find(t => t.Subjects.Average(s => s.Id) == maxAverageMark);

		Console.WriteLine($"{talabaWithMaxAverageMark.Ism} " +
			$"{talabaWithMaxAverageMark.Familiya} - {maxAverageMark:F2}");
	}

	static string GenerateRandomName()
	{
		string[] names = { "John", "Emily", "Michael", "Sophia",
			"Daniel", "Olivia","David", "Emma", "Andrew", "Isabella" };

		Random random = new Random();

		return names[random.Next(names.Length)];
	}

	static string GenerateRandomLastName()
	{
		string[] lastNames = { "Smith", "Johnson", "Williams", "Jones",
			"Brown", "Davis","Miller", "Wilson", "Moore", "Taylor" };

		Random random = new Random();

		return lastNames[random.Next(lastNames.Length)];
	}

	static string GenerateRandomPhoneNumber()
	{
		Random random = new Random();
		string countryCode = "+998";
		string operatorCode = (random.Next(2) == 0) ? "90" : "91";
		string number = random.Next(1000000, 9999999).ToString();

		return $"{countryCode}{operatorCode}{number}";
	}

	static string GenerateRandomEmail()
	{
		string[] domains = { "gmail.com", "yahoo.com", "hotmail.com",
			"outlook.com","icloud.com" };

		Random random = new Random();
		string name = GenerateRandomName().ToLower() + GenerateRandomLastName().ToLower();
		string domain = domains[random.Next(domains.Length)];

		return $"{name}@{domain}";
	}

	static DateTime GenerateRandomBirthDate()
	{
		Random random = new Random();
		int year = random.Next(1980, 2004);
		int month = random.Next(1, 13);
		int day = random.Next(1, DateTime.DaysInMonth(year, month) + 1);

		return new DateTime(year, month, day);
	}

	static string GenerateRandomRegNumber()
	{
		Random random = new Random();
		return $"REG{random.Next(1000, 9999)}";
	}

	static string GenerateRandomSubject()
	{
		string[] subjects = { "Math", "Physics", "Chemistry", "Biology", "History",
			"English", "Computer Science", "Art", "Music" };

		Random random = new Random();
		return subjects[random.Next(subjects.Length)];
	}

	static int CalculateAge(DateTime birthDate)
	{
		int age = DateTime.Now.Year - birthDate.Year;
		if (birthDate > DateTime.Now.AddYears(-age))
			age--;
		return age;
	}
}

class Talaba
{
	public int Id { get; set; }
	public string Ism { get; set; }
	public string Familiya { get; set; }
	public string Telefon { get; set; }
	public string Email { get; set; }
	public DateTime TugilganSana { get; set; }
	public string StudentRegNumber { get; set; }
	public List<Subject> Subjects { get; set; }

	public Talaba()
	{
		Subjects = new List<Subject>();
	}
}

class Oqituvchi
{
	public int Id { get; set; }
	public string Ism { get; set; }
	public string Familiya { get; set; }
	public string Telefon { get; set; }
	public string Email { get; set; }
	public DateTime TugilganSana { get; set; }
}

class Subject
{
	public int Id { get; set; }
	public string Ism { get; set; }
}