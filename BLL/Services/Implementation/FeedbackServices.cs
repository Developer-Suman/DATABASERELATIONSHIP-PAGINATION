using AutoMapper;
using BLL.DTOs.Feedback;
using BLL.Repository.Interface;
using BLL.Services.Interface;
using DAL.DbContext;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class FeedbackServices : IFeedbackServices
    {
        private readonly IUnitOfWorkTwo uow;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public FeedbackServices(IUnitOfWorkTwo unitOfWorkTwo, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            uow = unitOfWorkTwo;
            _context = applicationDbContext;
            _mapper = mapper;
            
        }
        public async Task<FeedbackGetDTOs> CreateFeedback(FeedbackCreateDTOs feedbackCreateDTOs)
        {
            try
            {
                var feedbackToBeCreated = _mapper.Map<Feedback>(feedbackCreateDTOs);
                await uow.Repository<Feedback>().Add(feedbackToBeCreated);
                await uow.SaveChangesAsync();
                return _mapper.Map<FeedbackGetDTOs>(feedbackToBeCreated);

            }catch(Exception ex)
            {
                throw new Exception("An error occured while saving or creating Feedback");
            }
        }

        public async Task<bool> DeleteFeedback(int FeedbackId)
        {
            try
            {
                var feedback = await uow.Repository<Feedback>().GetById(FeedbackId) ?? throw new Exception("Feedback not Found");
                uow.Repository<Feedback>().Delete(feedback);
                await uow.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occured while deleting");
            }
        }

        public async Task<List<FeedbackGetDTOs>> GetAllFeedbacks()
        {
            try
            {
                var feedback = await _context.Feedbacks.AsNoTracking().Include(x=>x.Product).ToListAsync();
                List<FeedbackGetDTOs> feedbackdtos = feedback.Select(feedback => new FeedbackGetDTOs
                {
                    FeedbackId = feedback.FeedbackId,
                    Product = feedback.Product,
                    FeedbackName = feedback.FeedbackName,

                }).ToList();   
                return feedbackdtos;


            }
            catch(Exception ex)
            {
                throw new Exception("Ann errorOccured while get all Feedback");
            }
        }

        public async Task<FeedbackGetDTOs> GetFeedbacksById(int FeedbackId)
        {
            try
            {
                var feedback = await uow.Repository<Feedback>().GetById(FeedbackId);
                var feedbackDTOs = _mapper.Map<FeedbackGetDTOs>(feedback);
                return feedbackDTOs;

            }catch(Exception ex)
            {
                throw new Exception("An error occured while get feedback by Id");
            }
        }

        public async Task<FeedbackGetDTOs> UpdateFeedback(FeedbackUpdateDTOs feedbackUpdateDTOs)
        {
            try
            {
                var feedback = await uow.Repository<Feedback>().GetById(feedbackUpdateDTOs.FeedbackId);
                if(feedback is null)
                {
                    throw new Exception("Feedback is null, unable to update feedback");

                }
                var feedbackToBeupdated = _mapper.Map<Feedback>(feedbackUpdateDTOs);
                uow.Repository<Feedback>().Update(feedbackToBeupdated);
                await uow.SaveChangesAsync();

                return _mapper.Map<FeedbackGetDTOs>(feedbackToBeupdated);


            }catch(Exception ex)
            {
                throw new Exception("An error while Updating", ex);
            }
        }
    }
}
