using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using MlkPwgen;
using System.Text.RegularExpressions;
using tmretApi.Data;
using tmretApi.Dtos;
using tmretApi.Entities;
using tmretApi.Helpers;
using tmretApi.Migrations;
using XAPI;

namespace MahberApi.Services.TemretExecutive
{
    public class DegafiRepository : IDegafiRepostiory
    {

        private readonly ApplicationDbContext _context;
        public DegafiRepository(ApplicationDbContext context)
        {
            _context = context;


        }


        public async Task CreateFromExcel(FansFromExcel fansFromExcel)
        {


            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            List<ExcelFans> fans = new List<ExcelFans>();
            using (var stream = new MemoryStream())
            {

                fansFromExcel.excelFile.CopyTo(stream);
                stream.Position = 0;
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read()) //Each row of the file
                    {
                        fans.Add(new ExcelFans { name = reader.GetValue(0)?.ToString(), gender = reader.GetValue(1)?.ToString(), address = reader.GetValue(2)?.ToString(), fantype = reader.GetValue(3)?.ToString(), phonenumber = reader.GetValue(4)?.ToString(), jobtype = reader.GetValue(5)?.ToString() });
                    }
                }
            }

            int i = 0;
            foreach (var fan in fans)
            {
                if (i != 0)


                {

                    try
                    {

                        var degafi = new Degafi();



                        degafi.ID = Guid.NewGuid();
                        degafi.createdAt = DateTime.UtcNow;
                        degafi.createdBy = Guid.Parse(fansFromExcel.mahberId);
                        degafi.PhoneNumber = fan.phonenumber;
                        degafi.Address = fan.address;
                        degafi.AddressAmharic = fan.address;
                        degafi.BirthDate = "20/10/1997";
                        degafi.Name = fan.name;
                        degafi.AmharicName = fan.name;

                        degafi.Gender = fan.gender=="M"||fan.gender=="ወ" ?Gender.Male :Gender.Female;





                        var degafiId = "";

                        var degse = _context.DegafiSettings.Where(x => x.Name == fan.fantype || x.AmharicName == fan.fantype).FirstOrDefault();
                        if (degse != null)
                        {
                            degafiId = degse.IdInitial;

                            var lastId = _context.Degafi.Where(x => x.DegafiSettingId == degse.ID).OrderByDescending(x => x.idNumber).FirstOrDefault();

                            if (lastId != null)
                            {
                                var resultString = Regex.Match(lastId.idNumber, @"\d+").Value;
                                degafiId += (Int32.Parse(resultString) + 1).ToString();
                            }
                            else
                            {
                                degafiId += degse.StartFrom;
                            }

                        }

                        degafi.idNumber = degafiId;
                        degafi.UserPhoto = "Assets/Degafi_upload_photo/3ac86993-07dd-42c0-841a-6e3e3ae94554.png";
                        degafi.DegafiSettingId = degse.ID;
                        degafi.JobType = fan.jobtype;
                        degafi.MahberId = Guid.Parse(fansFromExcel.mahberId);


                        await _context.Degafi.AddAsync(degafi);
                        await _context.SaveChangesAsync();


                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }



                }

                i++;


            }











            // await _context.SaveChangesAsync();
        }

        public async Task Create(Degafi degafi)
        {
            try
            {
                var degafiId = "";

                var degse = _context.DegafiSettings.Find(degafi.DegafiSettingId);
                if (degse != null)
                {
                    degafiId = degse.IdInitial;

                    var lastId = _context.Degafi.Where(x => x.DegafiSettingId == degafi.DegafiSettingId).OrderByDescending(x => x.idNumber).FirstOrDefault();

                    if (lastId != null)
                    {
                        var resultString = Regex.Match(lastId.idNumber, @"\d+").Value;
                        degafiId += (Int32.Parse(resultString) + 1).ToString();
                    }
                    else
                    {
                        degafiId += degse.StartFrom;
                    }

                }

                degafi.idNumber = degafiId;
                if (degafi.Photo != null)
                {
                    var image = degafi.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Degafi_upload_photo/"), degafi.ID.ToString() + fileExtension);



                    await image.SaveAsAsync(savingPath);
                    degafi.UserPhoto = "Assets/Degafi_upload_photo/" + degafi.ID + fileExtension;
                }


                await _context.Degafi.AddAsync(degafi);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task CreatePayment(Payment Payment)
        {
            try
            {


                var degafi = _context.Degafi.Include(x => x.DegafiSetting).Where(x => x.ID == Payment.DegafiId).FirstOrDefault();
                var penality = 0.0;
                if (degafi.DegafiSetting.HasPenality)
                {

                    var prevDate = getGeDate(Payment.StartDate);
                    var today = DateTime.Now;

                    var diffodDates = today.Subtract(prevDate);

                    if (diffodDates.Days > 0)
                    {
                        penality = degafi.DegafiSetting.PenalityAmount * (diffodDates.Days / degafi.DegafiSetting.IncreasesEvery) * degafi.DegafiSetting.MultiplyAmount;
                    }

                    Payment.Penality = (float)penality;
                }


                var ethDate = Payment.StartDate.Split('/');
                var day = ethDate[0];
                var month = Int32.Parse(ethDate[1]);
                var year = Int32.Parse(ethDate[2]);

                for (int i = 0; i < Payment.month; i++)
                {

                    month += 1;
                    if (month > 12)
                    {
                        month = 1;
                        year += 1;
                    }
                }

                Payment.EndDate = day + "/" + month.ToString() + "/" + year.ToString();




                await _context.Payments.AddAsync(Payment);
                await _context.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<List<Degafi>> GetAll(Guid mahberId)
        {

            var mahber = await _context.DefafiMahbers.Where(x => x.UserId == mahberId).FirstOrDefaultAsync();

            if (mahber != null)
            {

                return await _context.Degafi.Include(x => x.DegafiSetting).Include(x => x.Payments).Include(y => y.Mahber).Where(x => x.MahberId == mahber.ID).ToListAsync();
            }
            else { return new List<Degafi>(); }

        }



        public async Task<List<Payment>> GetAllPaymentsByid(Guid fanId)
        {
            return await _context.Payments.Where(x => x.DegafiId == fanId).OrderByDescending(x => x.createdAt).ToListAsync();
        }

        public async Task Update(Degafi degafi)
        {
            try
            {

                var Degafis = _context.Degafi.Find(degafi.ID);


                if (degafi.Name != null)
                    Degafis.Name = degafi.Name;
                if (degafi.DegafiSettingId != Guid.Empty)
                    Degafis.DegafiSettingId = degafi.DegafiSettingId;
                if (degafi.BirthDate != null)
                    Degafis.BirthDate = degafi.BirthDate;
                if (degafi.PhoneNumber != null)
                    Degafis.PhoneNumber = degafi.PhoneNumber;
                if (degafi.Description != null)
                    Degafis.Description = degafi.Description;
                if (degafi.IsActive)
                    Degafis.IsActive = degafi.IsActive;
                if (degafi.IdGiven)
                    Degafis.IdGiven = degafi.IdGiven;

                Degafis.Gender = degafi.Gender;
                Degafis.AmharicName = degafi.AmharicName;


                if (degafi.Photo != null)
                {
                    var image = degafi.Photo;
                    var photoinfo = new FileInfo(Path.GetFileName(image.FileName));
                    var fileExtension = photoinfo.Extension;
                    var savingPath = Path.Combine(Path.GetDirectoryName("./Assets/Executives_upload_photo/"), degafi.ID.ToString() + fileExtension);

                    if (File.Exists(savingPath))
                    {
                        File.Delete(savingPath);
                    }

                    await image.SaveAsAsync(savingPath);
                    Degafis.UserPhoto = "Assets/Executives_upload_photo/" + degafi.ID + fileExtension;
                }


                _context.Degafi.Update(Degafis);
                _context.SaveChanges();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public string getDate()
        {

            var date = DateTime.Now;

            var amharicDate = XAPI.EthiopicDateTime.GetEthiopicDate(date.Day, date.Month, date.Year);


            return amharicDate;
        }

        public DateTime getGeDate(string date)
        {



            DateTime gergorianDate = DateTime.Now;
            if (date != null)
            {

                var dates = date.Split("/");

                if (dates.Length == 3)
                {
                    gergorianDate = XAPI.EthiopicDateTime.GetGregorianDate(Int32.Parse(dates[0]), Int32.Parse(dates[1]), Int32.Parse(dates[2]));

                }
            }

            return gergorianDate;
        }


        public double getPenality(string startDate, Guid degafiId)
        {
            var degafi = _context.Degafi.Include(x => x.DegafiSetting).Where(x => x.ID == degafiId).FirstOrDefault();
            var penality = 0.0;
            if (degafi.DegafiSetting.HasPenality)
            {

                var prevDate = getGeDate(startDate);
                var today = DateTime.Now;

                var diffodDates = today.Subtract(prevDate);

                if (diffodDates.Days > 0)
                {
                    penality = degafi.DegafiSetting.PenalityAmount * (diffodDates.Days / degafi.DegafiSetting.IncreasesEvery) * degafi.DegafiSetting.MultiplyAmount;
                }

            }

            return penality;
        }






    }
}
