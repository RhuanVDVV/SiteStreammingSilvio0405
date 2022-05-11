#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SiteStreammingSilvio0405.BancoDeDados;
using SiteStreammingSilvio0405.Models;

namespace SiteStreammingSilvio0405.Controllers
{
    public class StreammingsController : Controller
    {
        private readonly Contexto _context;

        public StreammingsController(Contexto context)
        {
            _context = context;
        }
        public string VerificaExtensao(string nomeArquivo)
        {
            string extensaoArquivo = System.IO.Path.GetExtension(nomeArquivo).ToLower();
            string[] validacaoLista = { ".gif", ".jpeg", ".jpg", ".png", ".mp4", ".mp3" };
            foreach (string extensao in validacaoLista)
            {
                if (extensao == extensaoArquivo)
                {
                    return extensao;
                }
            }
            return "none";
        }

        // GET: Streammings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Streammings.ToListAsync());
        }
        public async Task<IActionResult> Galeria()
        {
            return View(await _context.Streammings.ToListAsync());
        }
        // GET: Streammings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streamming = await _context.Streammings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (streamming == null)
            {
                return NotFound();
            }

            return View(streamming);
        }

        // GET: Streammings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Streammings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Size,Tipo,Titulo,Descricao")] Streamming streamming, IFormFile arquivo)
        {
            var fileName = arquivo.FileName;
            var fileTam = arquivo.Length;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arq/", fileName);
            if (streamming.Descricao != null)
            {
                streamming.Titulo = fileName;
                streamming.Size = (int)fileTam;
                streamming.Tipo = VerificaExtensao(fileName);
                using (var localFile = System.IO.File.OpenWrite(filePath))
                using (var uploadedFile = arquivo.OpenReadStream())
                {
                    uploadedFile.CopyTo(localFile);
                }

                _context.Add(streamming);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(streamming);
        }

        // GET: Streammings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streamming = await _context.Streammings.FindAsync(id);
            if (streamming == null)
            {
                return NotFound();
            }
            return View(streamming);
        }

        // POST: Streammings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Size,Tipo,Titulo,Descricao")] Streamming streamming, IFormFile arquivo)
        {

            if (arquivo != null)
            {
                var dataImagemAntes = await _context.Streammings.FindAsync(id);
                var nomeArquivoAntes = dataImagemAntes.Titulo;
                var nomeArquivoAtual = arquivo.FileName;


                if (nomeArquivoAtual != nomeArquivoAntes)
                {
                    var nomeArquivoAtual_comURL = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arq/", nomeArquivoAtual);
                    System.IO.File.Delete(nomeArquivoAtual_comURL);
                    using (var localFile = System.IO.File.OpenWrite(nomeArquivoAtual_comURL))
                    using (var uploadedFile = arquivo.OpenReadStream())
                    {
                        uploadedFile.CopyTo(localFile);
                    }
                    dataImagemAntes.Titulo = nomeArquivoAtual;
                    dataImagemAntes.Size = (int)arquivo.Length;
                    dataImagemAntes.Tipo = VerificaExtensao(nomeArquivoAtual);
                    dataImagemAntes.Descricao = dataImagemAntes.Descricao;
                }


                _context.Update(streamming);
                await _context.SaveChangesAsync();

            }
            return View(streamming);
        }

        // GET: Streammings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streamming = await _context.Streammings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (streamming == null)
            {
                return NotFound();
            }

            return View(streamming);
        }

        // POST: Streammings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var streamming = await _context.Streammings.FindAsync(id);
            var stringEndereco = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/arq/", streamming.Titulo);
            if (!System.IO.File.Exists(stringEndereco))
            {
                return RedirectToAction(nameof(Index));
            }
            System.IO.File.Delete(stringEndereco);


            _context.Streammings.Remove(streamming);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreammingExists(int id)
        {
            return _context.Streammings.Any(e => e.Id == id);
        }
    }
}
