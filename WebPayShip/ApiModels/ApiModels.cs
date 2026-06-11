namespace WebPayShip.ApiModels
{
        public class ADD
        {
            public Guid AID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string PNumber { get; set; }
            public string Pcode { get; set; }

        }

        public class Card
        {
            public Guid CID { get; set; }
            public string Name { get; set; }
            public string CNumber { get; set; }
            public string EDate { get; set; }
            public string CVV { get; set; }

        }

        public class Bank
        {
            public Guid BID { get; set; }
            public string Holder { get; set; }
            public string BNumber { get; set; }
            public string BName { get; set; }

        }

        public class Gcash
        {
            public Guid GID { get; set; }
            public string Name { get; set; }
            public string GNumber { get; set; }

        }
}
