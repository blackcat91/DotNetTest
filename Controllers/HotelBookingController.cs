using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestTest.Data;
using RestTest.Models;

namespace RestTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HotelBookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public HotelBookingController(AppDbContext context)
        {
            _context = context; 
        }

        [HttpGet]
        public JsonResult GetAll()
        {
           IEnumerable<HotelBooking> books =  _context.Bookings.AsEnumerable();
            return new JsonResult(Ok(books));
        }

        [HttpGet]
        public JsonResult Get(int id)
        {
            var books = _context.Bookings.Find(id);
            if (books == null) return new JsonResult(NotFound());
            return new JsonResult(Ok(books));
        }


        [HttpPost]
       
        public JsonResult CreateEdit(HotelBooking booking)
        {
            if(booking.Id == 0 || booking.Id == null)
            {
                _context.Bookings.Add(booking);
              
            }
            else
            {
               var book =  _context.Bookings.Find(booking.Id);
               if (book == null) return new JsonResult(NotFound());
               book = booking;
             
            }
            _context.SaveChanges();
            return new JsonResult(Ok(booking));
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var books = _context.Bookings.Find(id);
            if (books == null) return new JsonResult(NotFound());
            _context.Bookings.Remove(books);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }
    }
}
