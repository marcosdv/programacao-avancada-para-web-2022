using MeusLivros.Domain.Entities;
using MeusLivros.Domain.Repositories;
using MeusLivros.Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MeusLivros.Website.Controllers;

public class LivroController : Controller
{
    private readonly ILivroRepository _livroRepository;
    private readonly IEditoraRepository _editoraRepository;

    public LivroController(ILivroRepository livroRepository, IEditoraRepository editoraRepository)
    {
        _livroRepository = livroRepository;
        _editoraRepository = editoraRepository;
    }

    public IActionResult Index()
    {
        var livros = _livroRepository.BuscarTodos();

        return View(livros);
    }

    public IActionResult Cadastro(int? id)
    {
        var editoras = _editoraRepository.BuscarTodos();

        if (id == null)
        {
            ViewBag.EditoraId = new SelectList(editoras, "Id", "Nome");
            return View();
        }

        var livro = _livroRepository.BuscarPorId(id ?? 0);
        if (livro == null)
            return View();

        ViewBag.EditoraId = new SelectList(editoras, "Id", "Nome", livro.EditoraId);

        return View(new LivroViewModel {
            Id = livro.Id,
            Nome = livro.Nome,
            EditoraId = livro.EditoraId
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Cadastro(LivroViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        if (model.Id > 0)
            _livroRepository.Alterar(new Livro(model.Id ?? 0, model.Nome, model.EditoraId));
        else
            _livroRepository.Inserir(new Livro(model.Nome, model.EditoraId));

        return RedirectToAction("Index");
    }

    public IActionResult Excluir(int id)
    {
        _livroRepository.Excluir(new Livro(id, "", 0));

        return RedirectToAction("Index");
    }
}