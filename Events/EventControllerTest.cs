//using Microsoft;
using web_api;
using web_api.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace TestProject1
{
    public class EventControllerTest
    {
        private readonly EventsController controller;

        public EventControllerTest()
        {
            var context = new DataContextFake();
            controller = new EventsController(context);
        }

        [Fact]
        public void Get_ReturnOk()
        {
            //AAA
           

            //Arrange - ארגון הנתונים הנדרשים להפעלת הפונקציה הנבדקת

            //Act - הפעלת הפונקציה הנבדקת
            var result = controller.Get();

            //Asser - הכרזה מה התוצאה הרצויה
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnOk()
        {
            var id = 1;

            var result = controller.Get(id);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetById_ReturnNotFound()
        {
            var id = 4;

            var result = controller.Get(id);

            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public void PutById_ReturnOk()
        {
            var id = 1;
            Event eve = new Event { Id = id, Title = "Title", Start = DateTime.Now, End = DateTime.Now};
            var result = controller.Put(id, eve);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void PutById_ReturnNotFound()
        {
            var id = 4;
            Event eve = new Event { Id = id, Title = "Title", Start = DateTime.Now, End = DateTime.Now };

            var result = controller.Put(id, eve);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void DeleteById_ReturnOk()
        {
            var id = 1;
            var result = controller.Delete(id);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void DeleteById_ReturnNotFound()
        {

            var id = 4;

            var result = controller.Delete(id);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Post_ReturnOk()
        {

            Event eve = new Event { Id = 5, Title = "Title", Start = DateTime.Now, End = DateTime.Now };

            var result = controller.Post(eve);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Post_ReturnNotFound()
        {


            Event eve = new Event { Id = 0, Title = "Title", Start = DateTime.Now, End = DateTime.Now };

            var result = controller.Post(eve);

            Assert.IsType<NotFoundResult>(result);
        }
    }
}