namespace VideoProject.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string  Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        //Navigation Property
        public MembershipType MembershipType { get; set; }
        //Foreign key
        public byte MembershipTypeId { get; set; }
    }
}