using FootballLeague.Data.Entities;
using FootballLeague.Mappers;
using FootballLeague.Models.TeamsVM;
using FootballLeague.Services.Contracts;
using FootballLeague.Services.CustomException;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamServices _teamServices;

        public TeamController(ITeamServices teamServices)
        {
            this._teamServices = teamServices;
        }

        public async Task<IActionResult> Index(int? currentPage, string search = null)
        {
            try
            {
                //string userId = FindCurrentUserId();

                int currPage = currentPage ?? 1;
                int totalPages = await _teamServices.GetPageCount(10);

                IEnumerable<Team> allTeams = null;

                if (!string.IsNullOrEmpty(search))
                {
                    allTeams = await _teamServices.SearchTeam(search, currPage);
                }
                else
                {
                    allTeams = await _teamServices.GetAllTeamsAsync(currPage);
                }

                IEnumerable<TeamViewModel> teamListing = allTeams
                    .Select(m => TeamMapper.MapTeam(m));
                TeamIndexViewMode teamVM = TeamMapper.MapFromTeamIndex(teamListing,
                    currPage, totalPages);

                #region For pagination buttons and distribution
                teamVM.CurrentPage = currPage;
                teamVM.TotalPages = totalPages;

                if (totalPages > currPage)
                {
                    teamVM.NextPage = currPage + 1;
                }

                if (currPage > 1)
                {
                    teamVM.PreviousPage = currPage - 1;
                }
                #endregion

                return View(teamVM);
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }

        public async Task<IActionResult> Detail(int Id)
        {
            try
            {
                Team team = await _teamServices.GetTeamAsync(Id);
                TeamViewModel teamModel = TeamMapper.MapTeam(team);

                return View("Detail", teamModel);
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeamViewModel viewModel)
        {
            try
            {
                Team mapTeam = TeamMapper.MapTeam(viewModel);
                Team team = await _teamServices.CreateTeamAsync(mapTeam);

                return RedirectToAction("Index", new { id = team.TeamId });
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }

        //За пълнене на формата със стойности
        [HttpGet]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            Team team = await _teamServices.GetTeamAsync(id);
            TeamViewModel mapTeam = TeamMapper.MapTeam(team);

            return View("Edit", mapTeam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeam(TeamViewModel viewModel)
        {
            try
            {
                Team mapToTeam = TeamMapper.MapTeam(viewModel);
                Team team = await _teamServices.EditTeamAsync(mapToTeam);

                return RedirectToAction("Index", new { id = team.TeamId });
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _teamServices.DeleteTeamAsync(Id);

                return RedirectToAction("Index");
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
