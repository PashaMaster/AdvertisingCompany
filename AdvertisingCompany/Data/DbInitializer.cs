using System;
using System.Linq;

namespace AdvertisingCompany.Models
{
    public class DbInitializer
    {
        public static void Initialize(OrderContext context)
        {
            context.Database.EnsureCreated();

            if (context.Orders.Any())
            {
                return;
            }
            
            int client_number = 35;
            int responsibleofficer_number = 35;
            int additionalservise_number = 35;
            int typeadvertisign_number = 35;
            int location_number = 300;
            int order_number = 300;
            
            Random randObj = new Random(1);

            string Name;
            string Adress;
            int PhoneNumber;

            string[] name_voc = { "Юрий","Петр","Иван","Василий","Павел","Вячеслав","Снежана","Денис","Екатерина","Виктория","Андрей","Дмитрий","Юлия", "Дмитрий" , "Владислав" , "Карина" , "Ксения" , "Антон" , "Станислав" };
            string[] adress_voc = { "пр. Речицкий, ", "ул. Ленина, ", "ул. Свиридова, ", "ул. Интернациональная, ", "ул. Садовая, ", "ул. Строителей, ", "пр. Демина, ", "ул. Советская, ", "ул. Космонавтов, ", "ул. Любанская, ", "ул. Барыкина, ", "ул. Быхова, ", "ул. Октября, ", "ул. Ломова, " };
            int count_name_voc = name_voc.GetLength(0);
            int count_adress_voc = adress_voc.GetLength(0);

            for (int clientID=1; clientID<=client_number;clientID++)
            {
                Name = name_voc[randObj.Next(count_name_voc)];
                Adress = adress_voc[randObj.Next(count_adress_voc)]+clientID.ToString();
                PhoneNumber = randObj.Next(1000000)+ 9999999;
                context.Clients.Add(
                new Client()
                {
                    Adress = Adress,
                    NameClient = Name,                    
                    PhoneNumber = PhoneNumber
                });
            }
            context.SaveChanges();

            for (int responsibleoficefrID = 1; responsibleoficefrID <= responsibleofficer_number; responsibleoficefrID++)
            {
                Name = name_voc[randObj.Next(count_name_voc)];
                Adress = adress_voc[randObj.Next(count_adress_voc)] + responsibleoficefrID.ToString();
                PhoneNumber = randObj.Next(1000000) + 9999999;
                context.ResponsibleOfficers.Add(
                new ResponsibleOfficer()
                {
                    Adress = Adress,
                    NameResponsibleOfficer = Name,
                    PhoneNumber = PhoneNumber
                });
            }
            context.SaveChanges();

            string Discription;
            string TypeAdvertisign;

            string[] discription_voc = { "Глобальная", "Месная (локальная)", "Межународная", "Общенациональная", "Региональная" };
            string[] typeadvertisign_voc = { "Телевизионная реклама", "Радиореклама", "Реклама в прессе", "Интернет-реклама", "Наружная реклама", "Внутренняя реклама", "Транзитная реклама", "Прямая реклама", "Печатная реклама", "Сувенирная реклама", "Рекламные мероприятия", "Реклама в местах продаж"};
            int count_discription_voc = discription_voc.GetLength(0);
            int count_typeadvertisign_voc = typeadvertisign_voc.GetLength(0);

            for (int typeadvertisignID = 1; typeadvertisignID <= typeadvertisign_number; typeadvertisignID++)
            {
                Discription = discription_voc[randObj.Next(count_discription_voc)];
                TypeAdvertisign = typeadvertisign_voc[randObj.Next(count_typeadvertisign_voc)] ;
                context.TypeAdvertisings.Add(
                new TypeAdvertising()
                {
                    NameTypeAdvertising = TypeAdvertisign,
                    DiscriptionTypeAdvertising = Discription                    
                });
            }
            context.SaveChanges();

            string AdditionalServise;

            string[] discriptionservice_voc = { "Высокое качество", "Быстрая работа", "Отличные специалисты", "Большой опыт работы", "Множество площадок для работы"};
            string[] additionalservise_voc = { "Защита", "Ежедневное обновление", "Изготовлениие логотипа", "Разработка дизайна листовок", "Создание сайта-визитки"};
            int count_discriptionservice_voc = discriptionservice_voc.GetLength(0);
            int count_additionalservise_voc = additionalservise_voc.GetLength(0);

            for (int additionalserviseID = 1; additionalserviseID <= additionalservise_number; additionalserviseID++)
            {
                Discription = discriptionservice_voc[randObj.Next(count_discriptionservice_voc)];
                AdditionalServise = additionalservise_voc[randObj.Next(count_additionalservise_voc)] ;
                context.AdditionalServises.Add(
                new AdditionalServise()
                {
                    NameAdditionalServise = AdditionalServise,
                    DiscriptionAdditionalServise = Discription
                });
            }
            context.SaveChanges();

            int taId;
            int asId;
            string Location;
            string LocationT;

            string[] location_voc = { "Одноразовая реклама", "Реклама на 10 дней", "Реклама на 1 месяц", "Реклама на 1 год" };
            string[] locationT_voc = { "Радио Маяк", "Портал tut.by", "Авто фирма FlorRussia", "Газата Петушок"};
            int count_location_voc = location_voc.GetLength(0);
            int count_locationT_voc = locationT_voc.GetLength(0);

            for (int locationID = 1; locationID <= location_number; locationID++)
            {
                Location = location_voc[randObj.Next(count_location_voc)];
                LocationT = locationT_voc[randObj.Next(count_locationT_voc)];
                taId = randObj.Next(1, typeadvertisign_number - 1);
                asId = randObj.Next(1, additionalservise_number - 1);
                context.Locations.Add(
                new Location()
                {
                    NameLocation=Location,
                    LocationT=LocationT,
                    AdditionalServiseID=asId,
                    TypeAdvertisingID=taId
                });
            }
            context.SaveChanges();

            int cId, lId, roId;
            int payment, price;
            DateTime dateN, dateB, dateE;
            string service;

            string[] service_voc = { "Дополнительная защита", "Отдельный сотрудник", "Дополнительное место расположения" };
            int count_service_voc = service_voc.GetLength(0);

            for (int orderID = 1; orderID <= order_number; orderID++)
            {
                dateN = DateTime.Now.Date;
                dateB = dateN.AddDays(-orderID);
                dateE = dateN.AddDays(+orderID);
                price = randObj.Next(100, 100000);
                payment = randObj.Next(1, 3);
                service = service_voc[randObj.Next(count_service_voc)];
                cId = randObj.Next(1, client_number - 1);
                lId = randObj.Next(1, location_number - 1);
                roId = randObj.Next(1, responsibleofficer_number - 1);
                context.Orders.Add(
                new Order()
                {
                    ClientID=cId,
                    Date=dateN,
                    DateOfBegin=dateB,
                    DateOfEnd=dateE,
                    LocationID=lId,
                    Price=price,
                    PaymentNote=payment,
                    ResponsibleOfficerID=roId,
                    Servise=service
                });
            }
            context.SaveChanges();
        }
    }
}
