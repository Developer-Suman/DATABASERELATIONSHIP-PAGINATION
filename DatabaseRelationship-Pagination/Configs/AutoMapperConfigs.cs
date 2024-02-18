using AutoMapper;
using BLL.DTOs.Categories;
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

            CreateMap<Category, CategoryGetDTOs>().ReverseMap();
            CreateMap<Category, CategoryUpdateDTOs>().ReverseMap();
            CreateMap<Category, CategoryGetDTOs>().ReverseMap();

            #endregion

            #region Product
            CreateMap<Product, ProductGetDTOs>().ReverseMap();
            CreateMap<Product, ProductUpdateDTOs>().ReverseMap();
            CreateMap<Product, ProductCreateDTOs>().ReverseMap();

            #endregion

            CreateMap<Feedback, FeedbackGetDTOs>().ReverseMap();
            CreateMap<FeedbackUpdateDTOs, Feedback>();
            CreateMap<FeedbackCreateDTOs, Feedback>();

        }
    }
}
