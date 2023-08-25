using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using ToDo.Business.CustomExceptions;
using ToDo.Business.Interfaces;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Dto.Contact;
using ToDo.Model.Entities;

namespace ToDo.Business.Implementations
{
    public class ContactBs : IContactBs
    {
        private readonly IContactRepository _repo;
        private readonly IMapper _mapper;

        public ContactBs(IContactRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int Id)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");
            var contact = await _repo.GetByIdAsync(Id);

            if (contact != null)
            {
                contact.IsDeleted = true;
                await _repo.UpdateAsync(contact);
                return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
            }
            throw new NotFoundException("Girilen id ye uygun iletişim bilgisi bulunamadı");
        }

        public async Task<ApiResponse<ContactGetDto>> GetByIdAsync(int Id, params string[] includeList)
        {
            if (Id <= 0)
                throw new BadRequestException("id değeri 0 dan büyük olmalıdır");

            var contact = await _repo.GetByIdAsync(Id, includeList);
            if (contact != null)
            {
                var dto = _mapper.Map<ContactGetDto>(contact);
                return ApiResponse<ContactGetDto>.Success(StatusCodes.Status200OK, dto);
            }
            throw new NotFoundException("İletişim Bilgisi Bulunamadı");
        }

        public async Task<ApiResponse<List<ContactGetDto>>> GetContactsAsync(params string[] includeList)
        {
            var contacts = await _repo.GetAllAsync(k => k.IsDeleted == false, includeList: includeList);
            //if (contacts.Count > 0)
            //{
            //    var returnList = _mapper.Map<List<ContactGetDto>>(contacts);
            //    var response = ApiResponse<List<ContactGetDto>>.Success(StatusCodes.Status200OK, returnList);
            //    return response;
            //}
            //throw new NotFoundException("Mesajlar Bulunamadı");
            var returnList = _mapper.Map<List<ContactGetDto>>(contacts);
            var response = ApiResponse<List<ContactGetDto>>.Success(StatusCodes.Status200OK, returnList);
            return response;
        }

        public async Task<ApiResponse<ContactGetDto>> InsertAsync(ContactPostDto dto)
        {
            if (dto == null)
                throw new BadRequestException("Kaydedilecek iletişim bilgisi yollamalısınız");

            if (dto.Subject == null)
                throw new BadRequestException("Konu Adı Boş Olamaz");
            if (dto.NameSurname == null)
                throw new BadRequestException("Ad Soyad Boş Olamaz");
            if (dto.Phone == null)
                throw new BadRequestException("Telefon Boş Olamaz");
            if (dto.Email == null)
                throw new BadRequestException("Email Boş Olamaz");

            var contact = _mapper.Map<Contact>(dto);

            var insertedContact = await _repo.InsertAsync(contact);
            var a = _mapper.Map<ContactGetDto>(insertedContact);

            return ApiResponse<ContactGetDto>.Success(StatusCodes.Status201Created, a);
        }
    }
}
