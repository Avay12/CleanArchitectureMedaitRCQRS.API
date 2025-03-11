using AutoMapper;
using CleanArchitectureMedaitRCQRS.Application.Blogs.Queries.GetBlogs;
using CleanArchitectureMedaitRCQRS.Domain.Entity;
using CleanArchitectureMedaitRCQRS.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureMedaitRCQRS.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        private CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog() { Name = request.Name, Description = request.Description, Author = request.Author };
            var result = await _blogRepository.CreateAsync(blogEntity);
            return _mapper.Map<BlogVm>(result);
        }
    }
}
