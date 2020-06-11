using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using RugbyLeague.Data.EfStructures;
using RugbyLeague.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RugbyLeague.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly RugbyLeagueDbContext _dbContext;
        private readonly IMapper _mapper;

        public PlayerRepository(RugbyLeagueDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<PlayerModel>> GetPlayersByTeamUid(Guid teamUid)
        {
            //var query = _dbContext.Player
            //    .Include(d => d.Team) //Not necessary
            //    .Where(p => p.Team.Uid == teamUid);

            //var result = await query.Select(p => _mapper.Map<PlayerModel>(p)).ToListAsync();

            var result = await _dbContext.Player
                .Where(p => p.Team.Uid == teamUid)
                .ProjectTo<PlayerModel>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return result;
        }

    }
}
