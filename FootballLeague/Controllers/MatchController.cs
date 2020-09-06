using FootballLeague.Data.Entities;
using FootballLeague.Mappers;
using FootballLeague.Models.MatchesVM;
using FootballLeague.Services.Contracts;
using FootballLeague.Services.CustomException;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballLeague.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchServices _matchServices;

        public MatchController(IMatchServices matchServices)
        {
            this._matchServices = matchServices;
        }

        public async Task<IActionResult> Index(int? currentPage, string search = null)
        {
            try
            {
                //string userId = FindCurrentUserId();

                int currPage = currentPage ?? 1;
                int totalPages = await _matchServices.GetPageCount(10);

                IEnumerable<Match> allMatches = null;

                if (!string.IsNullOrEmpty(search))
                {
                    allMatches = await _matchServices.SearchMatch(search, currPage);
                }
                else
                {
                    allMatches = await _matchServices.GetAllMatchesAsync(currPage);
                }

                IEnumerable<MatchViewModel> matchListing = allMatches
                    .Select(m => MatchMapper.MapMatch(m));
                MatchIndexViewMode matchVM = MatchMapper.MapFromMatchIndex(matchListing,
                    currPage, totalPages);

                #region For pagination buttons and distribution
                matchVM.CurrentPage = currPage;
                matchVM.TotalPages = totalPages;

                if (totalPages > currPage)
                {
                    matchVM.NextPage = currPage + 1;
                }

                if (currPage > 1)
                {
                    matchVM.PreviousPage = currPage - 1;
                }
                #endregion

                return View(matchVM);
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
        public async Task<IActionResult> Create(MatchViewModel viewModel)
        {
            try
            {
                Match mapMatch = MatchMapper.MapMatch(viewModel);
                Match match = await _matchServices.CreateMatchAsync(mapMatch);

                return RedirectToAction("Index", new { id = match.MatchId });
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }

        //За пълнене на формата със стойности
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            Match match = await _matchServices.GetMatchAsync(id);
            MatchViewModel mapMatch = MatchMapper.MapMatch(match);

            return View("Edit", mapMatch);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditMatch(MatchViewModel viewModel)
        {
            try
            {
                Match mapToMatch = MatchMapper.MapMatch(viewModel);
                Match match = await _matchServices.EditMatchAsync(mapToMatch);

                return RedirectToAction("Index", new { id = match.MatchId });
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
                await _matchServices.DeleteMatchAsync(Id);

                return RedirectToAction("Index");
            }
            catch (GlobalException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
