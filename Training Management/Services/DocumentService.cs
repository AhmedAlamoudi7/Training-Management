using AutoMapper;
using DocumentFormat.OpenXml.Spreadsheet;
using LockKeyNew.Core.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TrainingManagement.ViewModels;
using TrainingManagement.Dtos;
using System.Collections.Generic;
using Training_Management.Data;
using Training_Management.Models;
using TrainingManagement.Dtos.LoginDto;
using TrainingManagement.Exceptions;
using TrainingManagement.Helpers;
using Training_Management.ViewModels;
using Training_Management.Dtos;
using DocumentFormat.OpenXml.Math;
using Microsoft.Extensions.Hosting;
using DocumentFormat.OpenXml.InkML;
using Training_Management.Services;
using TrainingManagement.Constants;
using FireSharp.Interfaces;
using FireSharp.Response;
using FireSharp.Config;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace TrainingManagement.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly NoSqlDbContext _db;
        private readonly IMapper _mapper;
        public readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;
        private readonly IFileService fileService;
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "6ef986b79de3b362e2b5e0d69c1e628f63e7507f",
            BasePath = "https://trainee-cloud-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public DocumentService(IWebHostEnvironment env, IUserService userService,/*IEmailService emailService,*/ NoSqlDbContext db, IMapper mapper, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            //_emailService = emailService;
            _userService = userService;
            _env = env;
            this.fileService = fileService;
        }
        public async Task<List<DocumentViewModel>> GetAll(int id)
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Documents");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            var list = new List<DocumentViewModel>().Where(x => x.Trainee.Id == id).ToList();
            if (data != null)
            {
                foreach (var item in data)
                {
                    list.Add(JsonConvert.DeserializeObject<DocumentViewModel>(((JProperty)item).Value.ToString()));
                }
            }

            return list;
        }
        public async Task<int> Create(CreateDocumentDto dto)
        {

            try
            {
                var model = _mapper.Map<Document>(dto);
                if (dto.FileName != null)
                {
                    model.FileName = await fileService.SaveFile(dto.FileName, FolderNames.ImagesFolder);
                }
                client = new FireSharp.FirebaseClient(config);
                var data = model;

                PushResponse response = client.Push("Documents/", data);

                data.Id = response.Result.name;
                SetResponse setResponse = client.Set("Documents/" + data.Id, data);

                if (setResponse.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return 1;
                }
                else
                    return 0;

            }
            catch (Exception ex)
            {

            }
            return 0;

        }
        public void Delete(string Id)
        {

            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Delete("Documents/" + Id);
         }

    }
 
}
