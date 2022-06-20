using System.ComponentModel.DataAnnotations;

namespace RestTest.Models
{
    public class HotelBooking
    {
        [Key]
        public int Id { get; set; }

        public int RoomNum { get; set; }

        public String ClientName { get; set; }



    }
}
