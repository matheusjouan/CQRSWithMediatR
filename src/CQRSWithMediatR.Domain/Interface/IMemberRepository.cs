﻿using CQRSWithMediatR.Domain.Entities;

namespace CQRSWithMediatR.Domain.Interface;
public interface IMemberRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int id);
    Task<Member> AddMember(Member member);
    void UpdateMember(Member member);
    Task<Member> DeleteMember(int id);  
}
