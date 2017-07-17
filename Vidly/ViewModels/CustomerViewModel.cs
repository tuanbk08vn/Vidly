
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSubsriberdToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}