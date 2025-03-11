using AutoMapper;
using CleanArchitectureMedaitRCQRS.Domain.Repository;
using MediatR;

namespace CleanArchitectureMedaitRCQRS.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        public IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<List<BlogVm>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllAsync();
            //var blogList = blogs.Select(x => new BlogVm
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Author = x.Author
            //}).ToList();
            var blogList = _mapper.Map<List<BlogVm>>(blogs);
            return blogList;
        }
    }
}
