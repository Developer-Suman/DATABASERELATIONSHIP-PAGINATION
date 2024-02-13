﻿using AutoMapper;
using BLL.DTOs.Category;
using BLL.DTOs.Feedback;
using BLL.DTOs.Products;
using DAL.Models;

namespace DatabaseRelationship_Pagination.Configs
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            #region category

            CreateMap<Category, CategoryGetAllDTOs>().ReverseMap();

            #endregion

            #region Product
            CreateMap<Product, ProductGetDTOs>().ReverseMap();
            #endregion

            CreateMap<Feedback, FeedbackGetDTOs>().ReverseMap();
            CreateMap<FeedbackUpdateDTOs, Feedback>();
            CreateMap<FeedbackCreateDTOs, Feedback>();

        }
    }
}
